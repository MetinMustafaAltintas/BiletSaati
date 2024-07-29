using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class SessionScreen:BaseEntity
    {
        public int SessionID { get; set; }
        public int ScreenID { get; set; }

        // Reontional Properties

        public virtual Session Session { get; set; }
        public virtual Screen Screen { get; set; }
    }
}
