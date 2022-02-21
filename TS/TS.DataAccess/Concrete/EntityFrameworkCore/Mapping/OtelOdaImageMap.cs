using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelOdaImageMap : IEntityTypeConfiguration<OtelOdaImage>
    {
        public void Configure(EntityTypeBuilder<OtelOdaImage> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<OtelOda>(x => x.OtelOdas)
                .WithMany(x => x.OtelOdaImages)
                .HasForeignKey(x => x.OtelOdaId);


        }
    }
}
