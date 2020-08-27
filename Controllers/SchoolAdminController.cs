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
    public class SchoolAdminController : ApiController
    {
        private DatabaseContext _context;
        public SchoolAdminController()
        {
            _context = new DatabaseContext();
        }

        [Route("schooladmins")]
        [HttpGet]
        public IHttpActionResult GetSchoolAdmins()
        {
            return Ok(_context.SchoolAdmins.ToList().Select(Mapper.Map<SchoolAdmin, SchoolAdminDTO>));
        }

        [Route("schooladmin/{id}")]
        [HttpGet]
        public IHttpActionResult GetSchoolAdmin(int id)
        {
            var schoolAdmin = _context.SchoolAdmins.SingleOrDefault(c => c.id == id);

            if (schoolAdmin == null)
                return NotFound();

            return Ok(Mapper.Map<SchoolAdmin, SchoolAdminDTO>(schoolAdmin));
        }

        [Route("createschooladmin/{id}")]
        [HttpPost]
        public IHttpActionResult CreateSchoolAdmin(SchoolAdminDTO schoolAdminDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var schoolAdmin = Mapper.Map<SchoolAdminDTO, SchoolAdmin>(schoolAdminDTO);

            _context.SchoolAdmins.Add(schoolAdmin);
            _context.SaveChanges();

            schoolAdminDTO.id = schoolAdmin.id;

            return Created(new Uri(Request.RequestUri + "/" + schoolAdmin.id), schoolAdminDTO);
        }

        [Route("updateschooladmin/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateSchoolAdmin(int id, SchoolAdminDTO schoolAdminDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var schoolAdmin = _context.SchoolAdmins.SingleOrDefault(c => c.id == id);

            if (schoolAdmin == null)
                NotFound();

            Mapper.Map(schoolAdminDTO, schoolAdmin);
            _context.SaveChanges();

            return Ok();
        }

        [Route("deleteschooladmin/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSchoolAdmin(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var schoolAdmin = _context.SchoolAdmins.SingleOrDefault(c => c.id == id);

            if (schoolAdmin == null)
                NotFound();

            _context.SchoolAdmins.Remove(schoolAdmin);
            _context.SaveChanges();

            return Ok();
        }
    }
}
