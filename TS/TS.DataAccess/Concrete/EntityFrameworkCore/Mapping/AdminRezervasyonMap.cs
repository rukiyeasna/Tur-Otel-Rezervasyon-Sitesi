using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AdminRezervasyonMap : IEntityTypeConfiguration<AdminRezervasyon>
    {
        public void Configure(EntityTypeBuilder<AdminRezervasyon> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<TurBilgileri>(x => x.TurBilgileris)
                .WithMany(x => x.AdminRezervasyons)
                .HasForeignKey(x => x.TurId);         

            builder.HasOne<OtelBilgileri>(x => x.OtelBilgileris)
              .WithMany(x => x.AdminRezervasyons)
              .HasForeignKey(x => x.OtelId);
        }
    }
}
