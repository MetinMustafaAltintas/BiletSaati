using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.Category.PureVMs
{
    public class CreateCategoryPureVM
    {
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string CategoryName { get; set; }
    }
}
