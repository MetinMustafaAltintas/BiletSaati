using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.AppRoles.PureVMs
{
    public class UpdateRolePureVM
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        public string RoleName { get; set; }
    }
}
