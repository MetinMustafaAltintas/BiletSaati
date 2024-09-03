using Project.ENTITIES.Enums;

namespace Project.COREMVC.Areas.Admin.Models.Screen.PureVMs
{
    public class GetScreenAdminPureVM
    {
        public int ID { get; set; }
        public string ScreenName { get; set; }
        public ushort Capacity { get; set; }
        public string PlaceName { get; set; }
        public DataStatus Status { get; set; }
    }
}
