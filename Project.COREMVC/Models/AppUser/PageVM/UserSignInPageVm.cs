using Project.COREMVC.Models.AppUser.PureVM;
using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Models.AppUser.PageVM
{
    public class UserSignInPageVm
    {
        public UserSignInRequestModel UserSignInRequestModel { get; set; }
        [EmailAddress(ErrorMessage = "Email Formatında Giriş Yapınız")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}
