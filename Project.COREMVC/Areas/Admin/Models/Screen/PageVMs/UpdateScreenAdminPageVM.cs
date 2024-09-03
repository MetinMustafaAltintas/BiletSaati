using Project.COREMVC.Areas.Admin.Models.Place.PureVMs;
using Project.COREMVC.Areas.Admin.Models.Screen.PureVMs;

namespace Project.COREMVC.Areas.Admin.Models.Screen.PageVMs
{
    public class UpdateScreenAdminPageVM
    {
        public List<ScreenPlaceAdminPureVM> ScreenPlaceAdminPureVMs { get; set; }
        public UpdateScreenAdminPureVM UpdateScreenAdminPureVM { get; set; }
    }
}
