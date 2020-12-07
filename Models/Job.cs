using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication1.Models
{
    public class Job
    {
        public int id { get; set; }
        [Display(Name ="Job Name")]
        public string jobtitle { get; set; }
        [Display(Name = "Job Description")]
        [AllowHtml]
        public string jobdesc { get; set; }
        [Display(Name = "Job Image")]
        public string jobimage { get; set; }

        public decimal bonus { get; set; }
        public decimal pay { get; set; }


        [Display(Name = "Job Catagory")]
        public int catagoryid { get; set; }
        public string userid { get; set; }
      
        public virtual catagory catagory   { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}