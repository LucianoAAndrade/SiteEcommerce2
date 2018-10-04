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
    public class UserHelper
    {
        public class UsersHelper : IDisposable
        {

            private static ApplicationDbContext userContext = new ApplicationDbContext();
            private static EcommerceContext db = new EcommerceContext();

            //delatar usuarios
            public static bool DeleteUser(string userName)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userAsp = userManager.FindByEmail(userName);
                if (userAsp == null)
                {
                    return false;
                }

                var response = userManager.Delete(userAsp);
                return response.Succeeded;
            }

            //atualizar usuarios
            public static bool UpdateUserName(string currentUserName, string newUserName)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userAsp = userManager.FindByEmail(currentUserName);
                if (userAsp == null)
                {
                    return false;
                }

                userAsp.UserName = newUserName;
                userAsp.Email = newUserName;
                var response = userManager.Update(userAsp);
                return response.Succeeded;
            }

            public static void CheckRole(string roleName)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

                if (!roleManager.RoleExists(roleName))
                {
                    roleManager.Create(new IdentityRole(roleName));
                }
            }
            //checa se a um super usuario
            public static void CheckSuperUser()
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
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
            //cria um usuario comum
            public static void CreateUserASP(string email, string roleName)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userASP = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                };

                userManager.Create(userASP, email);
                userManager.AddToRole(userASP.Id, roleName);
            }
            //cria um usuario utilizando a superclasse
            public static void CreateUserASP(string email, string roleName, string password)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userASP = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                };

                userManager.Create(userASP, password);
                userManager.AddToRole(userASP.Id, roleName);
            }
            // redefine a senha
            public static async Task PasswordRecovery(string email)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
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
}