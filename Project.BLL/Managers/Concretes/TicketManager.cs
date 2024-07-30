using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class TicketManager:BaseManager<Ticket>, ITicketManager
    {
        ITicketRepository _Trep;
        public TicketManager(ITicketRepository trep):base(trep) 
        {
            _Trep = trep;
        }
    }
}
