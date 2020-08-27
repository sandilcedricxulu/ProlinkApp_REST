using System;
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
    public class GardianController : ApiController
    {
        private DatabaseContext _context;
        public GardianController()
        {
            _context = new DatabaseContext();
        }

        [Route("gardians")]
        [HttpGet]
        public IHttpActionResult GetGardian()
        {
            return Ok(_context.Gardians.ToList().Select(Mapper.Map<Gardian, GardianDTO>));
        }

        [Route("gardians/{id}")]
        [HttpGet]
        public IHttpActionResult GetGardian(int id)
        {
            var gardian = _context.Gardians.SingleOrDefault(c => c.id == id);

            if (gardian == null)
                return NotFound();

            return Ok(Mapper.Map<Gardian, GardianDTO>(gardian));
        }

        [Route("creategardian/{id}")]
        [HttpPost]
        public IHttpActionResult CreateGardian(GardianDTO gardianDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gardian = Mapper.Map<GardianDTO, Gardian>(gardianDTO);
            _context.Gardians.Add(gardian);
            _context.SaveChanges();

            gardianDTO.id = gardian.id;

            return Created(new Uri(Request.RequestUri + "/" + gardian.id), gardianDTO);
        }

        [Route("updategardian/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateGardian(int id, GardianDTO gardianDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gardian = _context.Gardians.SingleOrDefault(c => c.id == id);

            if (gardian == null)
                NotFound();

            Mapper.Map(gardianDTO, gardian);
            _context.SaveChanges();

            return Ok();
        }

        [Route("deletegardian/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteGardian(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var gardian = _context.Gardians.SingleOrDefault(c => c.id == id);

            if (gardian == null)
                NotFound();

            _context.Gardians.Remove(gardian);
            _context.SaveChanges();

            return Ok();
        }
    }
}
