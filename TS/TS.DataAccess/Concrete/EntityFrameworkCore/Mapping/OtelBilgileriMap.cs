using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelBilgileriMap : IEntityTypeConfiguration<OtelBilgileri>
    {
        public void Configure(EntityTypeBuilder<OtelBilgileri> builder)
        {
            builder.HasKey(I => I.OtelBilgiId);
            builder.Property(I => I.OtelBilgiId).UseIdentityColumn();

            builder.HasOne<TurBilgileri>(f => f.TurBilgileris)
               .WithMany(s => s.OtelBilgileris)
               .HasForeignKey(f => f.TurId);
        }
    }
}
