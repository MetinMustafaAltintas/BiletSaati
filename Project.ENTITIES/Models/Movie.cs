using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Movie:BaseEntity
    {
        public string MovieName { get; set; }
        public string Time { get; set; }
        public DateTime VisionDate { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }

        //Relational Properties

        public virtual ICollection<SessionMovie> SessionMovies { get; set; }
        public virtual ICollection<MovieCategory> MovieCategories { get; set; }
        public virtual ICollection<MovieComment> MovieComments { get; set; }
    }
}
