using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.COREMVC.Areas.Admin.Models.Place.PureVMs;
using Project.COREMVC.Areas.Admin.Models.Screen.PageVMs;
using Project.COREMVC.Areas.Admin.Models.Screen.PureVMs;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class ScreenController : Controller
    {
        readonly IScreenManager _screenManager;
        readonly IPlaceManager _placeManager;

        public ScreenController(IScreenManager screenManager, IPlaceManager placeManager)
        {
            _screenManager = screenManager;
            _placeManager = placeManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Screen> screens = await _screenManager.GetAllAsync();

            List<GetScreenAdminPureVM> getScreenAdminPureVMs = screens.Select(getScreenAdminPureVMs => new GetScreenAdminPureVM
            {
                ID = getScreenAdminPureVMs.ID,
                ScreenName = getScreenAdminPureVMs.ScreenName,
                PlaceName = getScreenAdminPureVMs.Place.PlaceName,
                Status = getScreenAdminPureVMs.Status,
                Capacity = getScreenAdminPureVMs.Capacity,
            }).ToList();

            GetScreenAdminPageVM pageVM = new();
            pageVM.getScreenAdminPureVMs = getScreenAdminPureVMs;
            return View(pageVM);
        }

        public async Task<IActionResult> CreateScreen()
        {
            List<Place> places = await _placeManager.GetActivesAsync();

            List<ScreenPlaceAdminPureVM> screenPlaces = places.Select(screenPlaces => new ScreenPlaceAdminPureVM
            {
                ID = screenPlaces.ID,
                PlaceName = screenPlaces.PlaceName
            }).ToList();

            CreateScreenAdminPageVM pageVM = new();
            pageVM.ScreenPlaceAdminPureVMs = screenPlaces;
            return View(pageVM);
        }
        [HttpPost]
        public async Task<IActionResult> CreateScreen(CreateScreenAdminPageVM model)
        {
            Screen screen = new();
            screen.ScreenName = model.CreateScreenAdminPureVM.ScreenName;
            screen.Capacity = model.CreateScreenAdminPureVM.Capacity;
            screen.PlaceID = model.CreateScreenAdminPureVM.PlaceID;
            await _screenManager.AddAsync(screen);
            TempData["Message"] = $"{screen.ScreenName} verisi Eklendi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetScreen(int id)
        {
            Place place = await _placeManager.FindAsync(id);

            List<Screen> screens = await _screenManager.WhereAsync(x => x.Place.PlaceName == place.PlaceName);
            if (screens.Count == 0)
            {
                TempData["Message2"] = $"{place.PlaceName} Salon yoktur.";
                return RedirectToAction("Index", "Place");
            }

            List<GetScreenAdminPureVM> getScreenAdminPureVMs = screens.Select(getScreenAdminPureVMs => new GetScreenAdminPureVM
            {
                ID = getScreenAdminPureVMs.ID,
                ScreenName = getScreenAdminPureVMs.ScreenName,
                PlaceName = getScreenAdminPureVMs.Place.PlaceName,
                Status = getScreenAdminPureVMs.Status,
                Capacity = getScreenAdminPureVMs.Capacity,
            }).ToList();

            GetScreenAdminPageVM pageVM = new();
            pageVM.getScreenAdminPureVMs = getScreenAdminPureVMs;
            return View(pageVM);
        }

        public async Task<IActionResult> UpdateScreen(int id)
        {
            Screen screen = await _screenManager.FindAsync(id);

            UpdateScreenAdminPureVM pureVM = new();
            pureVM.ScreenName = screen.ScreenName;
            pureVM.ID = screen.ID;
            pureVM.Capacity = screen.Capacity;
            pureVM.PlaceID = screen.Place.ID;

            List<Place> places = await _placeManager.GetActivesAsync();

            List<ScreenPlaceAdminPureVM> screenPlaces = places.Select(screenPlaces => new ScreenPlaceAdminPureVM
            {
                ID = screenPlaces.ID,
                PlaceName = screenPlaces.PlaceName
            }).ToList();

            UpdateScreenAdminPageVM pageVM = new();
            pageVM.ScreenPlaceAdminPureVMs= screenPlaces;
            pageVM.UpdateScreenAdminPureVM = pureVM;            
            return View(pageVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateScreen(UpdateScreenAdminPageVM model)
        {
            Screen screen = await _screenManager.FindAsync(model.UpdateScreenAdminPureVM.ID);

            screen.ScreenName = model.UpdateScreenAdminPureVM.ScreenName;
            screen.Capacity = model.UpdateScreenAdminPureVM.Capacity;
            screen.PlaceID = model.UpdateScreenAdminPureVM.PlaceID;
            await _screenManager.UpdateAsync(screen);
            TempData["Message"] = $"{screen.ScreenName} verisi Güncellendi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteScreen(int id)
        {
            TempData["Message"] = await _screenManager.DeleteAsync(await _screenManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyScreen(int id)
        {
            TempData["Message"] = await _screenManager.DestroyAsync(await _screenManager.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
