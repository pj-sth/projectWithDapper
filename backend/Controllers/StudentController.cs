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
    public class StudentController : Controller
    {
        private readonly IConfiguration _config;
        
        public StudentController(IConfiguration config)
        {
            _config = config;
        }      

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("ConnectionString"));
            IEnumerable<Student> students = await SelectAllStudents(connection);
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(StudentVM student)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("ConnectionString"));
            await connection.ExecuteAsync("insert into students (studentname) values (@studentname)", student);
            return Ok(await SelectAllStudents(connection));
        }

        private static async Task<IEnumerable<Student>> SelectAllStudents(NpgsqlConnection connection)
        {
            return await connection.QueryAsync<Student>("select * from students");
        }
    }
}