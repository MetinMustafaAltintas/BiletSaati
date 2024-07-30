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
    public class PlaceManager:BaseManager<Place>, IPlaceManager
    {
        IPlaceRepository _Plrep;
        public PlaceManager(IPlaceRepository plrep):base(plrep)
        {
            _Plrep = plrep;
        }
    }
}
