using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.GetPay
{
    public class all : GetSomething
    {
        public decimal getbonus()
        {
            return 5;
        }

        public decimal getpay()
        {
            return 500;
        }
    }
}