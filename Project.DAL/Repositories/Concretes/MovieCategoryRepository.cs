using Microsoft.Identity.Client.Extensibility;
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
    public class MovieCategoryRepository : BaseRepository<MovieCategory> , IMovieCategoryRepository
    {
        public MovieCategoryRepository(MyContext db):base(db)
        {

        }
    }
}
