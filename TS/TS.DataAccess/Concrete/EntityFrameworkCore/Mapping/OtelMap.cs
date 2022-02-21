using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelMap : IEntityTypeConfiguration<Otel>
    {
        public void Configure(EntityTypeBuilder<Otel> builder)
        {
            builder.HasKey(I => I.OtelId);
            builder.Property(I => I.OtelId).UseIdentityColumn();

        }
    }
}
