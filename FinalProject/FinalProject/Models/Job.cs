using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TestAScore { get; set; }
        public int TestBScore { get; set; }
        public int TestCScore { get; set; }
    }
}