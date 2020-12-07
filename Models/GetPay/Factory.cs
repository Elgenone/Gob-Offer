using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.GetPay
{
    public class Factory
    {

        public GetSomething Employee(string role)
        {
         
             GetSomething  returnValue = null;

            if (role == "admin" || role == "admins")
            {
                returnValue = new Admin();
                return returnValue;
            }
            else if (role == "manager")
            {
                returnValue = new Manager();
                return returnValue;
            }
          
            returnValue = new all();
            return returnValue;
        }
              
    }
}