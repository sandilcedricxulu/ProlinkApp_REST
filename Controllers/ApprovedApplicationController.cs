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
    public class ApprovedApplicationController : ApiController
    {
        private DatabaseContext _context;
        public ApprovedApplicationController()
        {
            _context = new DatabaseContext();
        }

        [Route("approvedapplications")]
        [HttpGet]
        public IHttpActionResult GetApproved()
        {
            return Ok(_context.ApprovedApplications.ToList().Select(Mapper.Map<ApprovedApplications, ApprovedApplicationsDTO>));
        }

        [Route("approvedapplication/{id}")]
        [HttpGet]
        public IHttpActionResult GetApprovedApplications(int id)
        {
            var approvedApplications = _context.ApprovedApplications.SingleOrDefault(c => c.id == id);

            if (approvedApplications == null)
                return NotFound();

            return Ok(Mapper.Map<ApprovedApplications, ApprovedApplicationsDTO>(approvedApplications));
        }

        [Route("approvingapplication/{id}")]
        [HttpPost]
        public IHttpActionResult ApprovingApplication(ApprovedApplicationsDTO approvedApplicationsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var approvedApplications = Mapper.Map<ApprovedApplicationsDTO, ApprovedApplications>(approvedApplicationsDTO);
            _context.ApprovedApplications.Add(approvedApplications);
            _context.SaveChanges();

            approvedApplicationsDTO.id = approvedApplications.id;

            return Created(new Uri(Request.RequestUri + "/" + approvedApplications.id), approvedApplicationsDTO);
        }

        [Route("updateapprovedapplication/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateApprovedApplication(int id, ApprovedApplicationsDTO approvedApplicationsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var approvedApplications = _context.ApprovedApplications.SingleOrDefault(c => c.id == id);

            if (approvedApplications == null)
                NotFound();

            Mapper.Map(approvedApplicationsDTO, approvedApplications);
            _context.SaveChanges();

            return Ok();
        }


        [Route("deleteapprovedapplication/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteApprovedApplication(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var approvedApplication = _context.ApprovedApplications.SingleOrDefault(c => c.id == id);

            if (approvedApplication == null)
                NotFound();

            _context.ApprovedApplications.Remove(approvedApplication);
            _context.SaveChanges();

            return Ok();
        }
    }
}
