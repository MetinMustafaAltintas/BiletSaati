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
    public class AppUserRoleManager : BaseManager<AppUserRole>, IAppUserRoleManager
    {
        readonly IAppUserRoleRepository _Aurrep;
        public AppUserRoleManager(IAppUserRoleRepository aurrep) : base(aurrep)
        {
            _Aurrep = aurrep;
        }


    }
}

