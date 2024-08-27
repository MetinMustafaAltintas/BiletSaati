using Project.COREMVC.Models.Home.PureVM;

namespace Project.COREMVC.Models.Home.PageVM
{
    public class CategoryCityPlacePageVM
    {
        public List<GetCategoryPureVM> GetCategoryPureVM { get; set; }
        public List<GetCityPureVM> GetCityPureVM { get; set; }
        public List<GetPlacePureVM> GetPlacePureVM { get; set; }
    }
}
