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
    public class BannedApplicationController : ApiController
    {
        private DatabaseContext _context;
        public BannedApplicationController()
        {
            _context = new DatabaseContext();
        }

        [Route("bannedapplications")]
        [HttpGet]
        public IHttpActionResult GetBannedApplications()
        {
            return Ok(_context.BannedApplications.ToList().Select(Mapper.Map<BannedApplications, BannedApplicationsDTO>));
        }

        [Route("bannedapplication/{id}")]
        [HttpGet]
        public IHttpActionResult GetBannedApplications(int id)
        {
            var bannedApplication = _context.BannedApplications.SingleOrDefault(c => c.id == id);

            if (bannedApplication == null)
                return NotFound();

            return Ok(Mapper.Map<BannedApplications, BannedApplicationsDTO>(bannedApplication));
        }

        [Route("banningapplication/{id}")]
        [HttpPost]
        public IHttpActionResult BanningApplication(BannedApplicationsDTO bannedApplicationsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bannedApplications = Mapper.Map<BannedApplicationsDTO, BannedApplications>(bannedApplicationsDTO);
            _context.BannedApplications.Add(bannedApplications);
            _context.SaveChanges();

            bannedApplicationsDTO.id = bannedApplications.id;

            return Created(new Uri(Request.RequestUri + "/" + bannedApplications.id), bannedApplicationsDTO);
        }

        [Route("updatebannedapplication/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateBannedApplication(int id, BannedApplicationsDTO bannedApplicationsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bannedApplications = _context.BannedApplications.SingleOrDefault(c => c.id == id);

            if (bannedApplications == null)
                NotFound();

            Mapper.Map(bannedApplicationsDTO, bannedApplications);
            _context.SaveChanges();

            return Ok();
        }


        [Route("deletebannedapplication/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBannedApplication(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var bannedApplication = _context.BannedApplications.SingleOrDefault(c => c.id == id);

            if (bannedApplication == null)
                NotFound();

            _context.BannedApplications.Remove(bannedApplication);
            _context.SaveChanges();

            return Ok();
        }
    }
}
