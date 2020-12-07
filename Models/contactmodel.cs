using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class contactmodel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string message { get; set; }
    }
}