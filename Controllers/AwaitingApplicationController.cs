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
    public class AwaitingApplicationController : ApiController
    {
        private DatabaseContext _context;
        public AwaitingApplicationController()
        {
            _context = new DatabaseContext();
        }
         
        [Route("awaitingapplications")]
        [HttpGet]
        public IHttpActionResult GetAwaitingApplications()
        {
            return Ok(_context.AwaitingApplications.ToList().Select(Mapper.Map<AwaitingApplications, AwaitingApplicationsDTO>));
        }

        [Route("awaitingapplication/{id}")]
        [HttpGet]
        public IHttpActionResult GetAwaitingApplication(int id)
        {
            var awaitingApplication = _context.AwaitingApplications.SingleOrDefault(c => c.id == id);

            if (awaitingApplication == null)
                return NotFound();

            return Ok(Mapper.Map<AwaitingApplications, AwaitingApplicationsDTO>(awaitingApplication));
        }

        [Route("apply/{id}")]
        [HttpPost]
        public IHttpActionResult Apply(AwaitingApplicationsDTO awaitingApplicationsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var awaitingApplication = Mapper.Map<AwaitingApplicationsDTO, AwaitingApplications>(awaitingApplicationsDTO);
            _context.AwaitingApplications.Add(awaitingApplication);
            _context.SaveChanges();

            awaitingApplicationsDTO.id = awaitingApplication.id;

            return Created(new Uri(Request.RequestUri + "/" + awaitingApplication.id), awaitingApplicationsDTO);
        }

        [Route("updateapplication/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateApplication(int id, AwaitingApplicationsDTO awaitingApplicationsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var awaitingApplication = _context.AwaitingApplications.SingleOrDefault(c => c.id == id);

            if (awaitingApplication == null)
                NotFound();

            Mapper.Map(awaitingApplicationsDTO, awaitingApplication);
            _context.SaveChanges();

            return Ok();
        }

        [Route("deleteapplication/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteApplication(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var awaitingApplication = _context.AwaitingApplications.SingleOrDefault(c => c.id == id);

            if (awaitingApplication == null)
                NotFound();

            _context.AwaitingApplications.Remove(awaitingApplication);
            _context.SaveChanges();

            return Ok();
        }
    }
}
