﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProlinkApplications.Models.ActionModels;
using ProlinkApplications.Models.Files.enums;

namespace ProlinkApplications.Models.Files
{
    public class StudentFile
    {
       // [Table("StudentFile")]

        [Key]
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int PersonId { get; set; }
        public virtual Student Student { get; set; }
        

    }
}