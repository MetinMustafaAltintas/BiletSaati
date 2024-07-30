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
    public class AppUserProfileManager : BaseManager<AppUserProfile>,IAppUserProfileManager
    {
        readonly IAppUserProfileRepository _Aupprep;
        public AppUserProfileManager(IAppUserProfileRepository aupprep):base(aupprep)
        {
            _Aupprep = aupprep;
        }
    }
}
