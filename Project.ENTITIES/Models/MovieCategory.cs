using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class MovieCategory
    {
        public int MovieID { get; set; }
        public int CategoryID { get; set; }

        // Relational Properties

        public virtual Movie Movie { get; set; }
        public virtual Category Category { get; set; }
    }
}
