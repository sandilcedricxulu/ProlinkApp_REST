using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProlinkApplications.Models.DTO
{
    public class ApprovedApplicationsDTO
    {
        public int id { get; set; }
        public string status { get; set; }
        public int schoolId { get; set; }
        public int applicantId { get; set; }
        public int schoolAdminId { get; set; }
        public int invoice { get; set; }
        public DateTime date { get; set; }
    }
}