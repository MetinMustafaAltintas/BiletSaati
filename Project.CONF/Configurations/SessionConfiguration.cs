using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Configurations
{
    public class SessionConfiguration:BaseConfiguration<Session>
    {
        public override void Configure(EntityTypeBuilder<Session> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Price).HasColumnType("money");
        }
    }
}
