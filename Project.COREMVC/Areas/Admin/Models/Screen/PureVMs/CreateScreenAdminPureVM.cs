using System.Reflection.Metadata.Ecma335;

namespace Project.COREMVC.Areas.Admin.Models.Screen.PureVMs
{
    public class CreateScreenAdminPureVM
    {
        public string ScreenName { get; set; }
        public ushort Capacity { get; set; }
        public int PlaceID { get; set; }
    }
}
