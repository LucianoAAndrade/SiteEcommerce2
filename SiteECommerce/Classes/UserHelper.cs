using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SiteECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace SiteECommerce.Classes
{
    public class UserHelper : IDisposable
    {
        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static EcommerceContext db = new EcommerceContext();

        public static void CheckRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<>);

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserManager<>);
            var email = WebConfigurationManager.AppSettings["AdminUser"];
            var password = WebConfigurationManager.AppSettings["AdminPassWord"];
            var useAsp = userManager.FindByName(email);
            if (useAsp == null)
            {
                CreateUserASP(email, "Admin", password);
                return;
            }
            userManager.AddToRole(useAsp.Id, "Admin");
        }
        public static void CreateUserASP(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserManager<>);
            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, email);
            userManager.AddToRole(userASP.Id, roleName);
        }
        public static async Task PasswordRecovery(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserManager<ApplicationUser>());
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                return;
            }
            var user = db.Users.Where(tp => tp.UserName == email).FirstOrDefault();
            if (userASP == null)
            {
                return;
            }
            var random = new Random();
            var newPassoword = string.Format("{0}{1}{2:04}*",
                user.FirtName.Trim().ToUpper().Substring(0, 1),
                user.LastName.Trim().ToLower(), random.Next(10000));

            userManager.RemovePassword(userASP.Id);
            userManager.AddPassword(userASP.Id, newPassoword);

            var subject = "A senha foi modificada";
            var body = string.Format(@"<h1>A senha foi modificad</h1>
            <p> Sua nova senha é: <strong>{0}</strong></p>
            <p>Sua senha foi alterada com sucesso", newPassoword);

            await MailHelper.SendMail(email, subject, body);
        }
        public void Dispose()
        {
            userContext.Dispose();
            db.Dispose();
        }
    }
}