namespace Project.COREMVC.Areas.Admin.Models.AppRoles.PureVMs
{
    public class AppRoleResponseModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool Checked { get; set; } //Kullanıcı benim gönderdigim response'taki role sahip mi
    }
}
