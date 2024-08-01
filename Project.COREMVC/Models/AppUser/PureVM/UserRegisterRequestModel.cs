using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Models.AppUser.PureVM
{
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Kullanıcı ismi")]
        [MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter alabilir")]
        [MinLength(3, ErrorMessage = "{0} en az {1} karakter alabilir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Şifre")]
        [MaxLength(16, ErrorMessage = "{0} en fazla {1} karakter alabilir")]
        [MinLength(8, ErrorMessage = "{0} en az {1} karakter alabilir")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Şifre tekrarı")]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email formatında giriniz")]

        public string Email { get; set; }


        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "İsim")]
        [MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter alabilir")]
        [MinLength(3, ErrorMessage = "{0} en az {1} karakter alabilir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Soyisim")]
        [MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter alabilir")]
        [MinLength(3, ErrorMessage = "{0} en az {1} karakter alabilir")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Ülke")]
        public string Country { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        [Display(Name = "Telefon numarası")]
        [MaxLength(11, ErrorMessage = "{0} en fazla {1} karakter alabilir")]
        [MinLength(11, ErrorMessage = "{0} en az {1} karakter alabilir")]
        [RegularExpression(@"^\d+$", ErrorMessage = "{0} sadece sayılardan oluşmalıdır")]
        public string PhoneNumber { get; set; }     
        public string? ProfilePhoto { get; set; }
    }
}
