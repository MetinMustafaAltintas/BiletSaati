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
    public class AppRoleManager : BaseManager<AppRole>, IAppRoleManager
    {
        readonly IAppRoleRepository _arrep;
        public AppRoleManager(IAppRoleRepository aarep) : base(aarep)
        {
            _arrep = aarep;
        }
    }
}
