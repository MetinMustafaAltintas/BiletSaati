using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Admin.Models.City.PureVMs;
using Project.COREMVC.Areas.Admin.Models.Place.PageVMs;
using Project.COREMVC.Areas.Admin.Models.Place.PureVMs;
using Project.COREMVC.Areas.Admin.Models.Screen.PageVMs;
using Project.COREMVC.Areas.Admin.Models.Screen.PureVMs;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class PlaceController : Controller
    {
        readonly IPlaceManager _placeManager;
        readonly ICityManager _cityManager;
        readonly IScreenManager _screenManager;
        public PlaceController(IPlaceManager placeManager, ICityManager cityManager, IScreenManager screenManager)
        {
            _placeManager = placeManager;
            _cityManager = cityManager;
            _screenManager = screenManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Place> places = await _placeManager.GetAllAsync();

            List<GetPlaceAdminPureVM> adminPureVMs = places.Select(adminPureVMs => new GetPlaceAdminPureVM
            {
                ID = adminPureVMs.ID,
                CityName = adminPureVMs.City.CityName,
                PlaceName = adminPureVMs.PlaceName,
                Status = adminPureVMs.Status,
            }).ToList();

            GetPlaceAdminPageVM pageVM = new GetPlaceAdminPageVM();
            pageVM.GetPlaceAdminPureVMs= adminPureVMs;
            return View(pageVM);
        }
        [HttpGet]
        public async Task<IActionResult> CreatePlace()
        {
            List<City> cities = await _cityManager.GetActivesAsync();

            List<PlaceCityAdminPureVM> pureVMs = cities.Select(pureVMs => new PlaceCityAdminPureVM
            {
                ID = pureVMs.ID,
                CityName = pureVMs.CityName
            }).ToList();

            CreatePlaceAdminPageVM adminPageVM = new CreatePlaceAdminPageVM();
            adminPageVM.PlaceCityAdminPureVMs = pureVMs;
            return View(adminPageVM);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlace(CreatePlaceAdminPageVM model)
        {
            Place place = new Place();
            place.PlaceName=model.CreatePlaceAdminPureVM.PlaceName;
            place.CityID=model.CreatePlaceAdminPureVM.CityID;
            await _placeManager.AddAsync(place);
            TempData["Message"] = $"{place.PlaceName} verisi Eklendi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdatePlace(int id)
        {
            Place place= await _placeManager.FindAsync(id);

            List<City> cities = await _cityManager.GetActivesAsync();

            List<PlaceCityAdminPureVM> pureVMs = cities.Select(pureVMs => new PlaceCityAdminPureVM
            {
                ID = pureVMs.ID,
                CityName = pureVMs.CityName
            }).ToList();

            UpdatePlaceAdminPureVM updatePlaceAdminPureVM = new();
            updatePlaceAdminPureVM.ID = place.ID;
            updatePlaceAdminPureVM.PlaceName = place.PlaceName;
            updatePlaceAdminPureVM.CityID = place.City.ID;

            UpdatePlaceAdminPageVM pageVM = new();
            pageVM.UpdatePlaceAdminPureVM = updatePlaceAdminPureVM;
            pageVM.PlaceCityAdminPureVMs = pureVMs;

            return View(pageVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePlace(UpdatePlaceAdminPageVM model)
        {
            Place place = await _placeManager.FindAsync(model.UpdatePlaceAdminPureVM.ID);

            place.PlaceName = model.UpdatePlaceAdminPureVM.PlaceName;
            place.CityID = model.UpdatePlaceAdminPureVM.CityID;
            await _placeManager.UpdateAsync(place);
            TempData["Message"] = $"{place.PlaceName} verisi Güncellendi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePlace(int id)
        {
            TempData["Message"] = await _placeManager.DeleteAsync(await _placeManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyPlace(int id)
        {
            TempData["Message"] = await _placeManager.DestroyAsync(await _placeManager.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
