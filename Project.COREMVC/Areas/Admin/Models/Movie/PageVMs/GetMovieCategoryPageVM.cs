using Project.COREMVC.Areas.Admin.Models.Movie.PureVMs;

namespace Project.COREMVC.Areas.Admin.Models.Movie.PageVMs
{
    public class GetMovieCategoryPageVM
    {
        public List<GetMovieCategoryPureVM>  GetMovieCategoryPureVMs { get; set; }
        public int MovieID { get; set; }
    }
}
