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
    public class SessionManager:BaseManager<Session>, ISessionManager
    {
        ISessionRepository _Ssrep;
        public SessionManager(ISessionRepository ssrep):base(ssrep) 
        {
            _Ssrep = ssrep;
        }
    }
}
