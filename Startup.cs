using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication2.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {      
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            singelton obj = singelton.getobject() ;
            obj.CreateDefaultRoleandUser();          
        }

      


        class singelton
        {
            private ApplicationDbContext db = new ApplicationDbContext();
            private singelton()
            {

            }
            public static int getinstance = 1;
            public static singelton getobject()
            {
                if (getinstance == 1)
                {
                    getinstance++;
                    return new singelton();
                }
                return null;
            }          
            public void CreateDefaultRoleandUser()
            {
                var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                IdentityRole role = new IdentityRole();

                if (!rolemanager.RoleExists("admins"))
                {
                    role.Name = "admins";
                    rolemanager.Create(role);
                    ApplicationUser user = new ApplicationUser();
                    user.UserName = "Ahmed";
                    user.Email = "Ahmed@Ahmed.com";
                    user.usertype = "admins";
                    var check = usermanager.Create(user, "12345Mm%");
                    if (check.Succeeded)
                    {
                        usermanager.AddToRoles(user.Id, "manager");
                    }
                }
            }
            //end the method
        }
        //end the singelton
    }
}
