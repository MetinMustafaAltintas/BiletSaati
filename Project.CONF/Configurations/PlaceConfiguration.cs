using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Configurations
{
    public class PlaceConfiguration:BaseConfiguration<Place>
    {
        public override void Configure(EntityTypeBuilder<Place> builder)
        {
            base.Configure(builder);
        }
    }
}
