using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelAdminRezervasyonMap : IEntityTypeConfiguration<OtelAdminRezervasyon>
    {
        public void Configure(EntityTypeBuilder<OtelAdminRezervasyon> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<Otel>(x => x.Otels)
                .WithMany(x => x.OtelAdminRezervasyons)
                .HasForeignKey(x => x.OtelId);

            builder.HasOne<OtelOda>(x => x.OtelOdas)
              .WithMany(x => x.OtelAdminRezervasyons)
              .HasForeignKey(x => x.OtelId);
        }
    }
}
