using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Buzakov.App.FiveFilms.Models;
using Buzakov.App.DataContext;
using System.Web.Mvc;

namespace Buzakov.App.FiveFilms
{

    public class ApplicationUserManager : UserManager<UserProfile, string>
    {

        public ApplicationUserManager(UserStore<UserProfile, Role, string, UserLogin, UserRole, UserClaim> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var dbContext = DependencyResolver.Current.GetService<ApplicationContext>();

            var manager = new ApplicationUserManager(new UserStore<UserProfile, Role, string, UserLogin,UserRole, UserClaim>(dbContext));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<UserProfile>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<UserProfile>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

    }

}