using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImagePath { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }

    }
}
