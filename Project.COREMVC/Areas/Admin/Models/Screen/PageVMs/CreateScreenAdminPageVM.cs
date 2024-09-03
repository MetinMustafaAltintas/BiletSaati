using Project.COREMVC.Areas.Admin.Models.Place.PureVMs;
using Project.COREMVC.Areas.Admin.Models.Screen.PureVMs;

namespace Project.COREMVC.Areas.Admin.Models.Screen.PageVMs
{
    public class CreateScreenAdminPageVM
    {
        public List<ScreenPlaceAdminPureVM> ScreenPlaceAdminPureVMs { get; set; }
        public CreateScreenAdminPureVM CreateScreenAdminPureVM { get; set; }
    }
}
