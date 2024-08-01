using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Models.AppUser.PureVM
{
    public class UserSignInRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Kullanıcı ismi")]
        [MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter alabilir")]
        [MinLength(3, ErrorMessage = "{0} en az {1} karakter alabilir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Şifre")]
        [MaxLength(16, ErrorMessage = "{0} en fazla {1} karakter alabilir")]
        [MinLength(3, ErrorMessage = "{0} en az {1} karakter alabilir")]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }

    }
}
