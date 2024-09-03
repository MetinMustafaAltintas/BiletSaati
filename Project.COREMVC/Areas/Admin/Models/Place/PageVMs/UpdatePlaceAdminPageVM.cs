using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Project.COREMVC.Areas.Admin.Models.City.PureVMs;
using Project.COREMVC.Areas.Admin.Models.Place.PureVMs;

namespace Project.COREMVC.Areas.Admin.Models.Place.PageVMs
{
    public class UpdatePlaceAdminPageVM
    {
        public List<PlaceCityAdminPureVM> PlaceCityAdminPureVMs { get; set; }
        public UpdatePlaceAdminPureVM UpdatePlaceAdminPureVM { get; set; }
    }
}
