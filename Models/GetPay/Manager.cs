using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Manager : GetSomething
    {
        public decimal getbonus()
        {
            return 10;
        }

        public decimal getpay()
        {
            return 1000;
        }
    }
}