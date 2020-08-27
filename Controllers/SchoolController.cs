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


namespace ProlinkApplications.Controllers
{
    public class SchoolController : ApiController
    {
        private DatabaseContext _context;
        public SchoolController()
        {
            _context = new DatabaseContext();
        }

        [Route("schools")]
        [HttpGet]
        public IHttpActionResult GetSchools()
        {
            return Ok(_context.Schools.ToList().Select(Mapper.Map<School, SchoolDTO>));
        }

        [Route("schools/{id}")]
        [HttpGet]
        public IHttpActionResult GetSchool(int id)
        {
            var school = _context.Schools.SingleOrDefault(c => c.id == id);

            if (school == null)
                return NotFound();

            return Ok(Mapper.Map<School, SchoolDTO>(school));
        }

        [Route("createschool/{id}")]
        [HttpPost]
        public IHttpActionResult CreateSchool(SchoolDTO schoolDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var school = Mapper.Map<SchoolDTO, School>(schoolDTO);
            _context.Schools.Add(school);
            _context.SaveChanges();

            schoolDTO.id = school.id;

            return Created(new Uri(Request.RequestUri + "/" + school.id), schoolDTO);
        }

        [Route("updateschool/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateSchool(int id, SchoolDTO schoolDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var school = _context.Schools.SingleOrDefault(c => c.id == id);

            if (school == null)
                NotFound();

            Mapper.Map(schoolDTO, school);
            _context.SaveChanges();

            return Ok();
        }

        [Route("deleteschool/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSchool(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var school = _context.Schools.SingleOrDefault(c => c.id == id);

            if (school == null)
                NotFound();

            _context.Schools.Remove(school);
            _context.SaveChanges();

            return Ok();
        }
    }
}
