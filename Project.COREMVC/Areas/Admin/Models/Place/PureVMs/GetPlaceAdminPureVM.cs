using Project.ENTITIES.Enums;

namespace Project.COREMVC.Areas.Admin.Models.Place.PureVMs
{
    public class GetPlaceAdminPureVM
    {
        public int ID { get; set; }
        public string PlaceName { get; set; }
        public string CityName { get; set; }
        public DataStatus Status { get; set; }
    }
}
