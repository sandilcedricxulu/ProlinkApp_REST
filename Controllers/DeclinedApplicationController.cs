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
    public class DeclinedApplicationController : ApiController
    {
        private DatabaseContext _context;
        public DeclinedApplicationController()
        {
            _context = new DatabaseContext();
        }

        [Route("declinedapplications")]
        [HttpGet]
        public IHttpActionResult GetDeclinedApplications()
        {
            return Ok(_context.DeclinedApplications.ToList().Select(Mapper.Map<DeclinedApplications, DeclinedApplicationsDTO>));
        }

        [Route("declinedapplication/{id}")]
        [HttpGet]
        public IHttpActionResult GetDeclinedApplication(int id)
        {
            var declinedApplication = _context.DeclinedApplications.SingleOrDefault(c => c.id == id);

            if (declinedApplication == null)
                return NotFound();

            return Ok(Mapper.Map<DeclinedApplications, DeclinedApplicationsDTO>(declinedApplication));
        }

        [Route("declineapplication/{id}")]
        [HttpPost]
        public IHttpActionResult DeclineApplication(DeclinedApplicationsDTO declinedApplicationsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var declinedApplications = Mapper.Map<DeclinedApplicationsDTO, DeclinedApplications>(declinedApplicationsDTO);
            _context.DeclinedApplications.Add(declinedApplications);
            _context.SaveChanges();

            declinedApplicationsDTO.id = declinedApplications.id;

            return Created(new Uri(Request.RequestUri + "/" + declinedApplications.id), declinedApplicationsDTO);
        }

        [Route("updatedeclinedapplication/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateDeclinedApplication(int id, DeclinedApplicationsDTO declinedApplicationsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var declinedApplications = _context.DeclinedApplications.SingleOrDefault(c => c.id == id);

            if (declinedApplications == null)
                NotFound();

            Mapper.Map(declinedApplicationsDTO, declinedApplications);
            _context.SaveChanges();

            return Ok();
        }

        [Route("deletedeclinedapplication/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteDeclinedApplication(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var declinedApplication = _context.DeclinedApplications.SingleOrDefault(c => c.id == id);

            if (declinedApplication == null)
                NotFound();

            _context.DeclinedApplications.Remove(declinedApplication);
            _context.SaveChanges();

            return Ok();
        }
    }
}
