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
    public class MovieManager:BaseManager<Movie>, IMovieManager
    {
        IMovieRepository _Morep;
        public MovieManager(IMovieRepository morep):base(morep)
        {
            _Morep = morep;
        }
    }
}
