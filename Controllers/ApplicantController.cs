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
    public class ApplicantController : ApiController
    {
        private DatabaseContext _context;
        public ApplicantController()
        {
            _context = new DatabaseContext();
        }

        [Route("applicants")]
        [HttpGet]
        public IHttpActionResult GetApplicants()
        {
            return Ok(_context.Applicants.ToList().Select(Mapper.Map<Applicant, ApplicantDTO>));
        }

        [Route("applicant/{id}")]
        [HttpGet]
        public IHttpActionResult GetApplicant(int id)
        {
            var applicant = _context.Applicants.SingleOrDefault(c => c.id == id);

            if (applicant == null)
                return NotFound();

            return Ok(Mapper.Map<Applicant, ApplicantDTO>(applicant));
        }

        [Route("applying/{id}")]
        [HttpPost]
        public IHttpActionResult Applying(ApplicantDTO applicantDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var applicant = Mapper.Map<ApplicantDTO, Applicant>(applicantDTO);
            _context.Applicants.Add(applicant);
            _context.SaveChanges();

            applicantDTO.id = applicant.id;

            return Created(new Uri(Request.RequestUri + "/" + applicant.id), applicantDTO);
        }

        [Route("updateapplying/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateApplying(int id, ApplicantDTO applicantDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var applicant = _context.Applicants.SingleOrDefault(c => c.id == id);

            if (applicant == null)
                NotFound();

            Mapper.Map(applicantDTO, applicant);
            _context.SaveChanges();

            return Ok();
        }


        [Route("deleteapplying/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteApplying(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var applicant = _context.Applicants.SingleOrDefault(c => c.id == id);

            if (applicant == null)
                NotFound();

            _context.Applicants.Remove(applicant);
            _context.SaveChanges();

            return Ok();
        }
    }
}
