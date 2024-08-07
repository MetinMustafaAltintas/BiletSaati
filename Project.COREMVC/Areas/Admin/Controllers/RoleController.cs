using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Managers.Abstracts;
using Project.COREMVC.Areas.Admin.Models.AppRoles.PageVMs;
using Project.COREMVC.Areas.Admin.Models.AppRoles.PureVMs;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class RoleController : Controller
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly IAppUserRoleManager _userRoleManager;

        public RoleController(RoleManager<AppRole> roleManager, IAppUserRoleManager userRoleManager)
        {
            _roleManager = roleManager;
            _userRoleManager = userRoleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<AppRole> userAppRole = await _roleManager.Roles.ToListAsync();

            List<GetRolePureVM> rolePureVMs = userAppRole.Select(rolePureVMs => new GetRolePureVM
            {
                ID = rolePureVMs.Id,
                RoleName = rolePureVMs.Name,
                Status = rolePureVMs.Status
            }).ToList();

            GetRolePageVM getRolePageVM = new()
            {
                 GetRolePureVMs = rolePureVMs,
            };
            return View(getRolePageVM);
        }

        public async Task<IActionResult> RoleCreate(GetRolePageVM model)
        {

            IdentityResult result = await _roleManager.CreateAsync(new()
            {
                Name = model.CreateRolePureVM.RoleName
            });

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateRole(string id)
        {
            AppRole Role = await _roleManager.FindByIdAsync(id);

            UpdateRolePureVM rolePureVM = new()
            {
                ID = Role.Id.ToString(),
                RoleName = Role.Name
            };

            UpdateRolePageVM rolePageVM = new();
            rolePageVM.UpdateRolePureVM = rolePureVM;
            return View(rolePageVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRolePageVM model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = await _roleManager.FindByIdAsync(model.UpdateRolePureVM.ID);
                if (role == null)
                {
                    TempData["Message"] = "Rol Bulunamadı";
                    return View();
                }
                string eskiRoleName = role.Name;
                role.Name = model.UpdateRolePureVM.RoleName;
                role.ModifiedDate = DateTime.Now;
                role.Status = ENTITIES.Enums.DataStatus.Updated;
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    TempData["Message"] = $"{eskiRoleName} isimli rol {role.Name} oldu";
                    return RedirectToAction("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                if (role.Status == ENTITIES.Enums.DataStatus.Deleted)
                {
                    await _roleManager.DeleteAsync(role);
                    TempData["Message"] = "Rol Silindi";
                    return RedirectToAction("Index");
                }
                TempData["Message"] = "Rol Pasif Değil";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Rol Bulunamadı";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PassiveRole(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                List<AppUserRole> appUserRole = await _userRoleManager.GetActivesAsync();
                foreach (AppUserRole item in appUserRole)
                {
                    if (item.RoleId == role.Id)
                    {
                        TempData["Message"] = "Role Pasife Alınamıyor Çünkü Bu Rolü Kullanan Başka Kullanıcı Var";
                        return RedirectToAction("Index");
                    }                    
                }
                role.Status = ENTITIES.Enums.DataStatus.Deleted;
                IdentityResult result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Rol Pasife Alındı";
                    return RedirectToAction("Index");
                }
                TempData["Message"] = "Rol Pasife Alınamadı";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Rol Bulunamadı";
            return RedirectToAction("Index");
        }
    }
}
