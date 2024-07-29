using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Configurations
{
    public class SessionScreenConfiguration:BaseConfiguration<SessionScreen>
    {
        public override void Configure(EntityTypeBuilder<SessionScreen> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.ScreenID,
                x.SessionID
            });
        }
    }
}
