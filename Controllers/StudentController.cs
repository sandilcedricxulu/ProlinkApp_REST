using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ProlinkApplications.Models;
using ProlinkApplications.Models.ActionModels;
using ProlinkApplications.Models.DataAccess;
using ProlinkApplications.Models.DTO;

namespace webServiceApp.Controllers
{
    public class StudentController : ApiController
    {
        private DatabaseContext _context;
        public StudentController()
        {
            _context = new DatabaseContext();
        }

        [Route("students")]
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            return Ok(_context.Students.ToList().Select(Mapper.Map<Student, StudentDTO>));
        }

        [Route("students/{id}")]
        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.id == id);

            if (student == null)
                return NotFound();

            return Ok(Mapper.Map<Student, StudentDTO>(student));
        }

        [Route("createstudent/{id}")]
        [HttpPost]
        public IHttpActionResult CreateStudent(StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = Mapper.Map<StudentDTO, Student>(studentDTO);
            _context.Students.Add(student);
            _context.SaveChanges();

            studentDTO.id = student.id;

            return Created(new Uri(Request.RequestUri + "/" + student.id), studentDTO);
        }

        [Route("updatestudent/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = _context.Students.SingleOrDefault(c => c.id == id);

            if (student == null)
                NotFound();

            Mapper.Map(studentDTO, student);
            _context.SaveChanges();

            return Ok();
        }

        [Route("deletestudent/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var student = _context.Students.SingleOrDefault(c => c.id == id);

            if (student == null)
                NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok();
        }
    }
}
