using Microsoft.AspNetCore.Identity;
using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppRoleRepository : BaseRepository<AppRole>, IAppRoleRepository
    {
        RoleManager<AppRole> _roleManager;
        public AppRoleRepository(MyContext db, RoleManager<AppRole> roleManager) : base(db)
        {
            _roleManager = roleManager;
        }
    }
}

