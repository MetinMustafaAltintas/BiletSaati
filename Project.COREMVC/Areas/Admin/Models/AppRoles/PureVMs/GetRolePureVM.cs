using Project.ENTITIES.Enums;

namespace Project.COREMVC.Areas.Admin.Models.AppRoles.PureVMs
{
    public class GetRolePureVM
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public DataStatus Status { get; set; }
    }
}
