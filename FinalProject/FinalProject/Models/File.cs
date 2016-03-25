using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class File
    {
        public int FileID { get; set; }
        public string FileName { get; set; }
        //public HttpPostedFileBase Resume { get; set; }
    }
}