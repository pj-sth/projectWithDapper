using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Models;
using backend.Data.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
        private readonly IConfiguration _config;
        
        public SubjectController(IConfiguration config)
        {
            _config = config;
        }      

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetSubjects()
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("ConnectionString"));
            IEnumerable<Subject> subjects = await SelectAllSubjects(connection);
            return Ok(subjects);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddSubject(SubjectVM subject)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("ConnectionString"));
            await connection.ExecuteAsync("insert into subjects (subjectName) values (@subjectName)", subject);
            return Ok(await SelectAllSubjects(connection));
        }

        private static async Task<IEnumerable<Subject>> SelectAllSubjects(NpgsqlConnection connection)
        {
            return await connection.QueryAsync<Subject>("select * from subjects");
        }
    }
}