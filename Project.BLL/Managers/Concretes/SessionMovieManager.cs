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
    public class SessionMovieManager:BaseManager<SessionMovie>, ISessionMovieManager
    {
        ISessionMovieRepository _Ssmrep;
        public SessionMovieManager(ISessionMovieRepository ssmrep):base(ssmrep)
        {
            _Ssmrep = ssmrep;
        }
    }
}
