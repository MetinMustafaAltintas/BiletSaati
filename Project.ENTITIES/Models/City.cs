using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class City:BaseEntity
    {
        public string CityName { get; set; }

        //Relational Properties

        public virtual ICollection<Place> Places { get; set; }
    }
}
