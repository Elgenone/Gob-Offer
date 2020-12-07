using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class catagory
    {
       public int id { get; set; }

        [Required]
        [Display(Name = "catagory Name")]
        public string catagoryname { get; set; }
        [Required]
        [Display(Name = "catagory Description")]
        public string catagorydesc { get; set; }

        public virtual ICollection<Job> jobs { get; set; }
    }
}