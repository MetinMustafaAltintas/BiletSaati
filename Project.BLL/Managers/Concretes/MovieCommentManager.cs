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
    public class MovieCommentManager:BaseManager<MovieComment>, IMovieCommentManager
    {
        IMovieCommentRepository _Mcrep;
        public MovieCommentManager(IMovieCommentRepository mcrep):base(mcrep) 
        {
            _Mcrep = mcrep;
        }
    }
}
