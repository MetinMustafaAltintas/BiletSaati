using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Models.AppUser.PureVM
{
    public class UserPasswordPureVM
    {
        public int id { get; set; }

        public Guid token { get; set; }
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        [MinLength(8, ErrorMessage = "Minimum {0} 8 karakter girilmesi gereklidir")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$", ErrorMessage = "Şifreniz en az 8 karakter uzunluğunda olmalı ve en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter içermelidir.")]
        [Display(Name = "Şifre")]
        public string NewPassword { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("NewPassword", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
