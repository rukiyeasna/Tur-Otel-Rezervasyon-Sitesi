using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelFavoriMap : IEntityTypeConfiguration<OtelFavori>
    {
        public void Configure(EntityTypeBuilder<OtelFavori> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<Otel>(x => x.Otels)
                .WithMany(x => x.OtelFavoris)
                .HasForeignKey(x => x.OtelId);

            builder.HasOne<AppUser>(x => x.AppUsers)
               .WithMany(x => x.OtelFavoris)
               .HasForeignKey(x => x.AppUserId);
        }
    }
}
