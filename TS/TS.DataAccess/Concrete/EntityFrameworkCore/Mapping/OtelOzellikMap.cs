using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelOzellikMap : IEntityTypeConfiguration<OtelOzellik>
    {

        public void Configure(EntityTypeBuilder<OtelOzellik> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<Otel>(x => x.Otels)
                .WithMany(x => x.OtelOzelliks)
                .HasForeignKey(x => x.OtelId);
        }
    }
}
