using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.Category.PureVMs
{
    public class UpdateCategoryPureVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string CategoryName { get; set; }
    }
}
