using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Spending_Web.Models;
using Spending_Web.Repository;
using Spending_Web.Validation;


namespace Spending_Web.Controllers
{
    public class AccessController : Controller
    {
        public IAccountRepository accountRepository = new AccountRepository();
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            accountRepository.AuthenAccount(account);

            if (accountRepository.AuthenAccount(account) != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountName),
                    new Claim("OtherProperties", "Example Role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                    );

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = account.KeepLoggedIn,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties
                    );

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "User not found.";
            return View();
        }


        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            account.Role = "user";

            Account accAth = accountRepository.GetAccountByAccountName(account.AccountName.Trim());
            if (accAth != null)
            {
                ViewData["status-register"] = "faild";
                ViewData["ValidateMessage"] = "Account already exists.";
                return View();
            }


            if (account.RePassword != account.Password)
            {
                ViewData["status-register"] = "faild";
                ViewData["ValidateMessage"] = "Password not duplicate.";
                return Register();
            }
            else
            {
                if (!Validator.IsValidPassword(account.Password))
                {
                    ViewData["status-register"] = "faild";
                    ViewData["ValidateMessage"] = "1. The password must be at least 8 characters long." +
                                        "\r\n2. The password must contain at least one uppercase letter." +
                                        "\r\n3. The password must contain at least one lowercase letter." +
                                        "\r\n4. The password must contain at least one digit." +
                                        "\r\n5. The password must contain at least one special character such as !@#$%^&*()_+{}|:\"<>?-=[];',./`~.";
                    return Register();
                }
            }

            accountRepository.InsertAccount(account);

            ViewData["status-register"] = "success";
            ViewData["ValidateMessage"] = "Successful account registration.";
            return View();
        }
    }
}
