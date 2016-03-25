using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class JobSeeker
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Info { get; set; }
        //public File Resume { get; set; }
        public int Survey1Score { get; set; }
        public bool Survey1Complete { get; set; }
        public string Survey2Score { get; set; }
        public bool Survey2Complete { get; set; }
        public string Survey3Score { get; set; }
        public bool Survey3Complete { get; set; }
        public int ResumeID { get; set; }
        public bool UploadedResume { get; set; }
        
    }
}