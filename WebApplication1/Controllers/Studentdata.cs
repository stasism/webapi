using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Studentdata : ControllerBase
    {

        private List<Student> _students = new List<Student> ()
        { 
            new Student() { ID=1, Name="Kārlis", Surname="Zags" },
            new Student() { ID=2, Name = "Pēteris", Surname = "Priede" },
            new Student() { ID=3, Name = "Jānis", Surname = "Bērzs" },
        };

    private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Studentdata> _logger;

        public Studentdata(ILogger<Studentdata> logger)
        {
            _logger = logger;
        }
         
        
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _students;
        }

        [HttpGet(template: "{ID}")]
        public Student GetById(int ID)
        {
            return _students.FirstOrDefault(s => s.ID == ID);
        }


        [HttpPost(template: "{ID}")]
        public int AddStudent (Student  student)
        {
            _students.Add(student);
            return _students.Count;
        }

        [HttpPut(template: "{ID}")]
        public Student UpdateStudent(Student student, int id)
        {
            var studentToUpdate = _students.FirstOrDefault(s => s.ID == id);
            studentToUpdate.Name = student.Name;
            studentToUpdate.Surname = student.Surname;

            return studentToUpdate;
        }

        [HttpDelete(template: "{ID}")]
        public void DeleteStudent(int id)
        {
            var studentToDelete = _students.FirstOrDefault(s => s.ID == id);
            _students.Remove(studentToDelete) ;
                        
        }

    }
}
