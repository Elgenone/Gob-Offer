using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication1.Models
{
    public class ApplyJob
    {
        public int id { get; set; }
        public string message { get; set; }
        public DateTime ApplyTime { get; set; }

        public int jobid { get; set; }
        public string userid { get; set; }

        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}