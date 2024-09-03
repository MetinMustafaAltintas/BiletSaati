using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Screen :BaseEntity
    {
        public string ScreenName { get; set; }
        public ushort Capacity { get; set; }
        public int PlaceID { get; set; }

        // Relational Properties

        public virtual Place Place { get; set; }
        public virtual ICollection<SessionScreen> SessionScreens { get; set; }
    }
}
