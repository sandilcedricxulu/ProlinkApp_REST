﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProlinkApplications.Models.ActionModels
{
    public class ProlinkAdmin
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string idNumber { get; set; }
        public string cellNumber { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}