﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Aptitude     /* test 1*/
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int Q1 { get; set;}
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public int Q5 { get; set; }
        public int CorrectAnswers { get; set; }
        public bool TestACompleted { get; set; }

    }
}