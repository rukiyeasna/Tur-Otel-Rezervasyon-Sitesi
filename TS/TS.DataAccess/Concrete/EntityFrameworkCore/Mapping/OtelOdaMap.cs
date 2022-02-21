using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelOdaMap : IEntityTypeConfiguration<OtelOda>
    {
        public void Configure(EntityTypeBuilder<OtelOda> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<Otel>(x => x.Otels)
                .WithMany(x => x.OtelOdas)
                .HasForeignKey(x => x.OtelId);

        }
    }
}
