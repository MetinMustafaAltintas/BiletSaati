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
    public class SessionScreenManager:BaseManager<SessionScreen>, ISessionScreenManager
    {
        ISessionScreenRepository _Sescrep;
        public SessionScreenManager(ISessionScreenRepository sescrep):base(sescrep) 
        {
            _Sescrep = sescrep;
        }
    }
}
