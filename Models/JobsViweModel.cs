using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class JobsViweModel
    {
       public string jobtitle { get; set; }
        public IEnumerable<ApplyJob> itemes { get; set; }

    }
}