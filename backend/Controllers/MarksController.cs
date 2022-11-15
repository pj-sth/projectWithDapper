using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarksController : Controller
    {
        private readonly IConfiguration _config;

        public MarksController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddMarks(MarksVM marks)
        {
            try {
                var query = 
                    "INSERT INTO marks (studentid, subjectid, marks) VALUES (@studentid, @subjectid, @marks)";
                    var parameters = new DynamicParameters();
                    parameters.Add("studentid", marks.studentid);
                    parameters.Add("subjectid", marks.subjectid);
                    parameters.Add("marks", marks.marks);
                    using (var connection = new NpgsqlConnection(_config.GetConnectionString("ConnectionString")))
                    {
                        await connection.ExecuteAsync(query, parameters);
                    }
                return marks.studentid;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }     
    };
}