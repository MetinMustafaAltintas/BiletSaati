using Project.ENTITIES.Enums;

namespace Project.COREMVC.Areas.Admin.Models.Session.PureVMs
{
    public class GetSessionAdminPureVM
    {
        public int ID { get; set; }
        public string ShowTime { get; set; }
        public decimal Price { get; set; }
        public DataStatus Status { get; set; }
    }
}
