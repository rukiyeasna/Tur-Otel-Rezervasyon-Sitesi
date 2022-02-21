using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelRezervasyonMap : IEntityTypeConfiguration<OtelRezervasyon>
    {
        public void Configure(EntityTypeBuilder<OtelRezervasyon> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<Otel>(x => x.Otels)
                .WithMany(x => x.OtelRezervasyons)
                .HasForeignKey(x => x.OtelId);

            builder.HasOne<AppUser>(x => x.AppUsers)
               .WithMany(x => x.OtelRezervasyons)
               .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<OtelOda>(x => x.OtelOdas)
              .WithMany(x => x.OtelRezervasyons)
              .HasForeignKey(x => x.OtelId);
        }
    }
}
