using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class SessionMovie:BaseEntity
    {
        public int SessionID { get; set; }
        public int MovieID { get; set; }

        //Relational Properties

        public virtual Session Session { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
