using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Admin.Models.City.PageVMs;
using Project.COREMVC.Areas.Admin.Models.City.PureVMs;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class CityController : Controller
    {
        readonly ICityManager _cityManager;

        public CityController(ICityManager cityManager)
        {
            _cityManager = cityManager;
        }

        public async Task<IActionResult> Index()
        {
            List<City> cityList = await _cityManager.GetAllAsync();

            List<GetCityAdminPureVM> pureVMs = cityList.Select(pureVMs => new GetCityAdminPureVM
            {
                ID = pureVMs.ID,
                CityName = pureVMs.CityName,
                Status = pureVMs.Status,
            }).ToList();

            GetCityAdminPageVM getCityAdminPageVM = new GetCityAdminPageVM();
            getCityAdminPageVM.GetCityAdminPureVMs = pureVMs;
            return View(getCityAdminPageVM);
        }

        public IActionResult CreateCity()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCityAdminPageVM model)
        {
            City city = new City();
            city.CityName = model.CreateCityAdminPureVM.CityName;
            await _cityManager.AddAsync(city);
            TempData["Message"] = $"{city.CityName} verisi Eklendi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCity(int id)
        {
            City city = await _cityManager.FindAsync(id);

            UpdateCityAdminPureVM updateCity = new()
            {
                ID = city.ID,
                CityName = city.CityName,
            };

            UpdateCityAdminPageVM adminPageVM = new UpdateCityAdminPageVM();
            adminPageVM.UpdateCityAdminPureVM = updateCity;
            return View(adminPageVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCity(UpdateCityAdminPageVM model)
        {
            City city = await _cityManager.FindAsync(model.UpdateCityAdminPureVM.ID);
            city.CityName = model.UpdateCityAdminPureVM.CityName;
            await _cityManager.UpdateAsync(city);
            TempData["Message"] = $"{city.CityName} verisi Güncelledi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCity(int id)
        {
            TempData["Message"] = await _cityManager.DeleteAsync(await _cityManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyCity(int id)
        {
            TempData["Message"] = await _cityManager.DestroyAsync(await _cityManager.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
