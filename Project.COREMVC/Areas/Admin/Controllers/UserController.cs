using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.COREMVC.Areas.Admin.Models.AppRoles.PageVMs;
using Project.COREMVC.Areas.Admin.Models.AppRoles.PureVMs;
using Project.COREMVC.Areas.Admin.Models.User.PageVMs;
using Project.COREMVC.Areas.Admin.Models.User.PureVMs;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class UserController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;


        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> nonAdminUsers = await _userManager.Users.Where(x => !x.UserRoles.Any(x => x.Role.Name == "Admin")).ToListAsync();

            List<UserPureVM> userVms = nonAdminUsers.Select(user => new UserPureVM
            {
                ID = user.Id,
                UserName = user.UserName,
                Email = user.Email
            }).ToList();

            UserPageVM userPageVM = new()
            {
                UserPureVMs = userVms
            };
            return View(userPageVM);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            AppUser appUser = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id);

            IList<string> userRoles = await _userManager.GetRolesAsync(appUser); // Elimize gecen kullanıcının rollerini verir

            List<AppRole> allRoles = _roleManager.Roles.ToList(); //bütün roller

            List<AppRoleResponseModel> roles = new();


            foreach (AppRole role in allRoles)
            {
                roles.Add(new()
                {
                    RoleID = role.Id,
                    RoleName = role.Name,
                    Checked = userRoles.Contains(role.Name)
                });
            }

            AppRolePageVM arPvm = new()
            {
                UserID = id,
                Roles = roles
            };
            TempData["Message"] = $"Kullanıcı Adı {appUser.UserName}  olan kişinin rol bilgileri";
            return View(arPvm);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(AppRolePageVM model)
        {
            AppUser appUser = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == model.UserID);
            IList<string> userRoles = await _userManager.GetRolesAsync(appUser);

            foreach (AppRoleResponseModel role in model.Roles)
            {
                if (role.Checked && !userRoles.Contains(role.RoleName)) await _userManager.AddToRoleAsync(appUser, role.RoleName);
                else if (!role.Checked && userRoles.Contains(role.RoleName)) await _userManager.RemoveFromRoleAsync(appUser, role.RoleName);
            }

            return RedirectToAction("Index");
        }


    }
}
