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
    public class CommentManager:BaseManager<Comment>, ICommentManager
    {
        ICommentRepository _Corep;
        public CommentManager(ICommentRepository corep):base(corep) 
        {
            _Corep = corep;
        }
    }
}
