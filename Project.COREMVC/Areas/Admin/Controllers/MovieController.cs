using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Admin.Models.AppRoles.PageVMs;
using Project.COREMVC.Areas.Admin.Models.AppRoles.PureVMs;
using Project.COREMVC.Areas.Admin.Models.Category.PageVMs;
using Project.COREMVC.Areas.Admin.Models.Movie.PageVMs;
using Project.COREMVC.Areas.Admin.Models.Movie.PureVMs;
using Project.ENTITIES.Models;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class MovieController : Controller
    {
        readonly IMovieManager _movieManager;
        readonly IMovieCategoryManager _movieCategoryManager;
        readonly ICategoryManager _categoryManager;
        public MovieController(IMovieManager movieManager, IMovieCategoryManager movieCategoryManager, ICategoryManager categoryManager)
        {
            _movieManager = movieManager;
            _movieCategoryManager = movieCategoryManager;
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Movie> movies = await _movieManager.GetAllAsync();

            List<GetMoviePureVM> moviePureVMs = movies.Select(moviePureVMs => new GetMoviePureVM
            {
                ID = moviePureVMs.ID,
                MovieName = moviePureVMs.MovieName,
                Description = moviePureVMs.Description,
                VisionDate = moviePureVMs.VisionDate,
                StartingDate = moviePureVMs.StartingDate,
                EndDate = moviePureVMs.EndDate,
                Time = moviePureVMs.Time,
                ImagePath1 = moviePureVMs.ImagePath1,
                ImagePath2 = moviePureVMs.ImagePath2,
                Status = moviePureVMs.Status
                
            }).ToList();


            GetMoviePageVM getMoviePage = new GetMoviePageVM();
            getMoviePage.GetMoviePureVMs = moviePureVMs;
            return View(getMoviePage);
        }

        public async Task<IActionResult> AssignCategory(int id)
        {
            Movie movie = await _movieManager.FindAsync(id);

            List<MovieCategory> movieCategories = await _movieCategoryManager.WhereAsync(x => x.MovieID == id);

            List<Category> categories = await _categoryManager.GetAllAsync();

            List<string> categoryNames = categories.Where(c => movieCategories.Any(mc => mc.CategoryID == c.ID)).Select(c => c.CategoryName).ToList();
            

            List<GetMovieCategoryPureVM> getMovieCategories = new List<GetMovieCategoryPureVM>();

            foreach (Category item in categories)
            {
                getMovieCategories.Add(new()
                {
                    CategoryID = item.ID,
                    CategoryName = item.CategoryName,
                    Checked = categoryNames.Contains(item.CategoryName)
                });
            }

            GetMovieCategoryPageVM pageVM = new GetMovieCategoryPageVM();
            pageVM.GetMovieCategoryPureVMs = getMovieCategories;
            pageVM.MovieID = id;
            
            TempData["Message"] = $"{movie.MovieName}  isimli filmin kategorileri";
            return View(pageVM);
        }

        [HttpPost]
        public async Task<IActionResult> AssignCategory(GetMovieCategoryPageVM model)
        {
            Movie movie = await _movieManager.FindAsync(model.MovieID);

            List<MovieCategory> movieCategories = await _movieCategoryManager.WhereAsync(x => x.MovieID == model.MovieID);

            List<Category> categories = await _categoryManager.GetAllAsync();

            List<string> categoryNames = categories.Where(c => movieCategories.Any(mc => mc.CategoryID == c.ID)).Select(c => c.CategoryName).ToList();

            foreach (GetMovieCategoryPureVM category in model.GetMovieCategoryPureVMs)
            {
                if (category.Checked && !categoryNames.Contains(category.CategoryName))
                {
                    MovieCategory AddMovieCategory = new();
                    AddMovieCategory.MovieID = model.MovieID;
                    AddMovieCategory.CategoryID = category.CategoryID;
                    await _movieCategoryManager.AddAsync(AddMovieCategory);
                }
                else if (!category.Checked && categoryNames.Contains(category.CategoryName))
                {
                    MovieCategory RemoveMovieCategory = await _movieCategoryManager.FirstOrDefaultAsync(x => x.MovieID == movie.ID && x.CategoryID == category.CategoryID);
                    await _movieCategoryManager.DeleteAsync(RemoveMovieCategory);
                    await _movieCategoryManager.DestroyAsync(RemoveMovieCategory);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMoviePageVM model,IFormFile formFile1,IFormFile formFile2)
        {
            Guid uniqueName = Guid.NewGuid();
            string extension = Path.GetExtension(formFile1.FileName); //dosyanın uzantısını ele gecirdik...
            model.CreateMoviePureVM.ImagePath1 = $"/images/{uniqueName}{extension}";

            string path = $"{Directory.GetCurrentDirectory()}/wwwroot{model.CreateMoviePureVM.ImagePath1}";
            FileStream stream = new(path, FileMode.Create);
            formFile1.CopyTo(stream);

            Guid uniqueName2 = Guid.NewGuid();
            string extension2 = Path.GetExtension(formFile2.FileName); //dosyanın uzantısını ele gecirdik...
            model.CreateMoviePureVM.ImagePath2 = $"/images/{uniqueName2}{extension2}";

            string path2 = $"{Directory.GetCurrentDirectory()}/wwwroot{model.CreateMoviePureVM.ImagePath2}";
            FileStream stream2 = new(path2, FileMode.Create);
            formFile2.CopyTo(stream2);

            Movie movie = new Movie();
            movie.MovieName = model.CreateMoviePureVM.MovieName;
            movie.Time=model.CreateMoviePureVM.Time;
            movie.VisionDate=model.CreateMoviePureVM.VisionDate;
            movie.ImagePath1=model.CreateMoviePureVM.ImagePath1;
            movie.ImagePath2=model.CreateMoviePureVM.ImagePath2;
            movie.Description=model.CreateMoviePureVM.Description;
            movie.StartingDate=model.CreateMoviePureVM.StartingDate;
            movie.EndDate=model.CreateMoviePureVM.EndDate;
            await _movieManager.AddAsync(movie);
            TempData["Message"] = $"{movie.MovieName} verisi Eklendi";
            return RedirectToAction("Index");
        }
    }
}
