using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.Movie.PureVMs
{
    public class CreateMoviePureVM
    {
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string MovieName { get; set; }
        public string Time { get; set; }
        public DateTime VisionDate { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
