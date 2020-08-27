using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProlinkApplications.Models.DTO
{
    public class BannedApplicationsDTO
    {
        public int id { get; set; }
        public string applicantId { get; set; }
        public string reason { get; set; }
        public DateTime dateTime { get; set; }
    }
}