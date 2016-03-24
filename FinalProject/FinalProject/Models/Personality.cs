using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Personality        /*  test 2*/
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public int Q5 { get; set; }
        public int Q6 { get; set; }
        public int Q7 { get; set; }
        public string PersonalityType { get; set; }
        public bool TestBCompleted { get; set; }
    }
}