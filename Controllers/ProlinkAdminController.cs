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
    public class ProlinkAdminController : ApiController
    {
        private DatabaseContext _context;
        public ProlinkAdminController()
        {
            _context = new DatabaseContext();
        }

        [Route("prolinkadmins")]
        [HttpGet]
        public IHttpActionResult GetProlinkAdmins()
        {
            return Ok(_context.ProlinkAdmins.ToList().Select(Mapper.Map<ProlinkAdmin, ProlinkAdminDTO>));
        }

        [Route("prolinkadmins/{id}")]
        [HttpGet]
        public IHttpActionResult GetProlinkAdmin(int id)
        {
            var prolinkAdmin = _context.ProlinkAdmins.SingleOrDefault(c => c.id == id);

            if (prolinkAdmin == null)
                return NotFound();

            return Ok(Mapper.Map<ProlinkAdmin, ProlinkAdminDTO>(prolinkAdmin));
        }

        [Route("createprolinkadmin/{id}")]
        [HttpPost]
        public IHttpActionResult CreateProlinkAdmin(ProlinkAdminDTO prolinkAdminDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var prolinkAdmin = Mapper.Map<ProlinkAdminDTO, ProlinkAdmin>(prolinkAdminDTO);
            _context.ProlinkAdmins.Add(prolinkAdmin);
            _context.SaveChanges();

            prolinkAdminDTO.id = prolinkAdmin.id;

            return Created(new Uri(Request.RequestUri + "/" + prolinkAdmin.id), prolinkAdminDTO);
        }

        [Route("updateprolinkadmin/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateProlinkAdmin(int id, ProlinkAdminDTO prolinkAdminDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var prolinkAdmin = _context.ProlinkAdmins.SingleOrDefault(c => c.id == id);

            if (prolinkAdmin == null)
                NotFound();

            Mapper.Map(prolinkAdminDTO, prolinkAdmin);
            _context.SaveChanges();

            return Ok();
        }

        [Route("deleteprolinkadmin/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProlinkAdmin(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var prolinkAdmin = _context.ProlinkAdmins.SingleOrDefault(c => c.id == id);

            if (prolinkAdmin == null)
                NotFound();

            _context.ProlinkAdmins.Remove(prolinkAdmin);
            _context.SaveChanges();

            return Ok();
        }
    }
}
