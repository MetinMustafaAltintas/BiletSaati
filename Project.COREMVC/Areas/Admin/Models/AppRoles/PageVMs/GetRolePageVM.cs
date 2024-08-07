using Project.COREMVC.Areas.Admin.Models.AppRoles.PureVMs;

namespace Project.COREMVC.Areas.Admin.Models.AppRoles.PageVMs
{
    public class GetRolePageVM
    {
        public List<GetRolePureVM> GetRolePureVMs { get; set; }
        public CreateRolePureVM CreateRolePureVM { get; set; }
    }
}
