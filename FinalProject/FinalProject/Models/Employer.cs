﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Employer
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Info { get; set; }
        public bool isSubscribed { get; set; }
        public string Email { get; set; }
        
    }
}