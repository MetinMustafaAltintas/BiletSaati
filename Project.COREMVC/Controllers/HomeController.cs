using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.COREMVC.Models;
using Project.COREMVC.Models.AppUser.PageVM;
using Project.ENTITIES.Models;
using System.Diagnostics;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Project.COREMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SignIn(string returnUrl)
        {
            UserSignInPageVm userSignInPageVm = new()
            {
                UserSignInRequestModel = new()
                {
                    ReturnUrl = returnUrl
                }
            };
            return View(userSignInPageVm);
        }



        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInPageVm pageVm)
        {


            AppUser appUser = await _userManager.FindByNameAsync(pageVm.UserSignInRequestModel.UserName);


            if (appUser != null)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(appUser, pageVm.UserSignInRequestModel.Password, pageVm.UserSignInRequestModel.RememberMe, true);


                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(pageVm.UserSignInRequestModel.ReturnUrl))
                    {
                        return Redirect(pageVm.UserSignInRequestModel.ReturnUrl);
                    }


                    IList<string> roles = await _userManager.GetRolesAsync(appUser);

                    if (roles.Contains("Admin"))
                    {
                        //                   Action ismi  Controller ismi  Route Value's�
                        return RedirectToAction("Index", "Home"/*, new { Area = "Admin" }*/);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                else if (result.IsLockedOut)
                {
                    DateTimeOffset? lockOutEndDate = await _userManager.GetLockoutEndDateAsync(appUser);
                    ModelState.AddModelError("", $"Hesab�n�z {(lockOutEndDate.Value.UtcDateTime - DateTime.UtcNow).TotalSeconds:0.00} boyunca kilitlenmi�tir l�tfen bekleyiniz");
                }
                else if (result.IsNotAllowed) // Mail onayl� de�ildir
                {
                    return RedirectToAction("MailPanel");
                }
                else
                {
                    string message = "";
                    if (appUser != null)
                    {
                        int maxFailed = _userManager.Options.Lockout.MaxFailedAccessAttempts;
                        message = $" E�er {maxFailed - await _userManager.GetAccessFailedCountAsync(appUser)} kez daha yanl�� girerseniz hesab�n�z {_userManager.Options.Lockout.DefaultLockoutTimeSpan} s�reyle kapat�lacakt�r";
                    }
                    ModelState.AddModelError("", message);
                }

            }
            else
            {
                TempData["Message"] = "Kullan�c� bulunamad�";

            }
            return View(pageVm);

        }


    }
}
