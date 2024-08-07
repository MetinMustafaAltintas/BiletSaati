using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.AppRoles.PureVMs
{
    public class CreateRolePureVM
    {
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        public string RoleName { get; set; }
    }
}
