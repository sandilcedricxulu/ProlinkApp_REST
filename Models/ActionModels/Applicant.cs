using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProlinkApplications.Models.ActionModels
{
    public class Applicant
    {
        public int id { get; set; }
        public string studentId { get; set; }
        public string gardianId { get; set; }
        public DateTime dateTime { get; set; }
    }
}