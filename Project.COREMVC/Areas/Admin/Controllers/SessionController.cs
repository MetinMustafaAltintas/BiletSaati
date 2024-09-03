using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Admin.Models.Session.PageVMs;
using Project.COREMVC.Areas.Admin.Models.Session.PureVMs;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class SessionController : Controller
    {
        readonly ISessionManager _sessionManager;

        public SessionController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Session> sessions = await _sessionManager.GetAllAsync();

            List<GetSessionAdminPureVM> pureVMs = sessions.Select(pureVMs => new GetSessionAdminPureVM
            {
                ID = pureVMs.ID,
                ShowTime = pureVMs.ShowTime,
                Price = pureVMs.Price,
                Status = pureVMs.Status,
            }).ToList();

            GetSessionAdminPageVM pageVM = new();
            pageVM.GetSessionAdminPureVMs = pureVMs;
            return View(pageVM);
        }

        public IActionResult CreateSession()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSession(CreateSessionAdminPageVM model)
        {
            Session session = new Session();
            session.ShowTime = model.CreateSessionAdminPureVM.ShowTime;
            session.Price = model.CreateSessionAdminPureVM.Price;
            await _sessionManager.AddAsync(session);
            TempData["Message"] = $"{session.ShowTime} saati Eklendi";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateSession(int id)
        {
            Session session = await _sessionManager.FindAsync(id);

            UpdateSessionAdminPureVM pureVM = new();
            pureVM.ShowTime = session.ShowTime;
            pureVM.Price = session.Price;
            pureVM.ID = id;

            UpdateSessionAdminPageVM pageVM = new();
            pageVM.UpdateSessionAdminPureVM = pureVM;
            return View(pageVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSession(UpdateSessionAdminPageVM model)
        {
            Session session = await _sessionManager.FindAsync(model.UpdateSessionAdminPureVM.ID);

            session.ShowTime = model.UpdateSessionAdminPureVM.ShowTime;
            session.Price = model.UpdateSessionAdminPureVM.Price;
            await _sessionManager.UpdateAsync(session);
            TempData["Message"] = $"{session.ShowTime} saati Güncelledi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSession(int id)
        {
            TempData["Message"] = await _sessionManager.DeleteAsync(await _sessionManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroySession(int id)
        {
            TempData["Message"] = await _sessionManager.DestroyAsync(await _sessionManager.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
