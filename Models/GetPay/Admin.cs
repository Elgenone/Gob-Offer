using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.GetPay
{
    public class Admin : GetSomething
    {
        public decimal getbonus()
        {
            return 20;
        }

        public decimal getpay()
        {
            return 2000;
        }
    }
}