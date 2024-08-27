using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Project.BLL.Managers.Abstracts;
using Project.ENTITIES.Models;

namespace Project.COREMVC.CustomTagHelpers
{
    [HtmlTargetElement("getMovieCategory")]
    public class MyCustomMovie:TagHelper
    {
        readonly ICategoryManager _categoryManager;
        readonly IMovieCategoryManager _movieCategoryManager;

        public MyCustomMovie(ICategoryManager categoryManager, IMovieCategoryManager movieCategoryManager)
        {
            _categoryManager = categoryManager;
            _movieCategoryManager = movieCategoryManager;
        }



        public int MovieID { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string html = "";
            List<Category> categories = await _categoryManager.GetAllAsync();

            List<MovieCategory> movieCategories = await _movieCategoryManager.WhereAsync(x => x.MovieID == MovieID);

            List<string> categoryNames = categories.Where(c => movieCategories.Any(mc => mc.CategoryID == c.ID)).Select(c => c.CategoryName).ToList();

            foreach (string category in categoryNames)
            {
                html += $"{category},";
            }

            html = html.TrimEnd(',');

            output.Content.SetHtmlContent(html);
        }
    }
}
