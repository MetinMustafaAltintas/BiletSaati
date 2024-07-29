using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Ticket:BaseEntity
    {
        public string SeatNumber { get; set; }
        public int AppUserID { get; set; }

        // Relational Properties

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<SessionTicket> SessionTickets { get; set; }

    }
}
