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
    public class StudentSubjectController : Controller
    {
        private readonly IConfiguration _config;

        public StudentSubjectController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student_Subject>>> GetStudentSubjectList()
        {
            try
            {
                var query = "SELECT * FROM studentsubjects";
                using (var connection = new NpgsqlConnection(_config.GetConnectionString("ConnectionString")))
                {
                    var result = await connection.QueryAsync<Student_Subject>(query);
                    return result.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student_Subject>>> GetStudentWithSubject(int id)
        {
            try
            {
                var query = "SELECT * FROM studentsubjects WHERE studentid = @id";
                using (var connection = new NpgsqlConnection(_config.GetConnectionString("ConnectionString")))
                {
                    var result = await connection.QueryAsync<Student_Subject>(query, new{id});
                    return result.ToList();    
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddStudentSubject(StudentSubjectVM studentsubject)
        {
            try 
            {
                var idList = studentsubject.subjectids.ToList();
                var listCount = idList.Count();

                for (int i = 0; i < listCount; i++)
                {
                    var query = 
                        "INSERT INTO studentsubjects (studentid, subjectid) VALUES (@studentid, @subjectid)";
                        var parameters = new DynamicParameters();
                        parameters.Add("studentid", studentsubject.studentid);
                        parameters.Add("subjectid", studentsubject.subjectids[i]);
                        using (var connection = new NpgsqlConnection(_config.GetConnectionString("ConnectionString")))
                        {
                            await connection.ExecuteAsync(query, parameters);
                        }
                }
                return studentsubject.studentid;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}