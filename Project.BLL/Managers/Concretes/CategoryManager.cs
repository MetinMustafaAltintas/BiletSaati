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
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        readonly ICategoryRepository _catRep;
        public CategoryManager(ICategoryRepository catRep) : base(catRep)
        {
            _catRep = catRep;
        }
    }
}
