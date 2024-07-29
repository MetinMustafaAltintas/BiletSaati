using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Place : BaseEntity
    {
        public string PlaceName { get; set; }
        public int CityID { get; set; }

        //Relational Properties

        public virtual City City { get; set; }

        public virtual ICollection<Screen> Screens { get; set; }


    }
}
