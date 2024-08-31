namespace Project.COREMVC.Areas.Admin.Models.Movie.PureVMs
{
    public class UpdateMoviePureVM
    {
        public int ID { get; set; }
        public string MovieName { get; set; }
        public string Time { get; set; }
        public DateTime VisionDate { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
    }
}
