using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OtelOdaOzellikMap : IEntityTypeConfiguration<OtelOdaOzellik>
    {
       
        public void Configure(EntityTypeBuilder<OtelOdaOzellik> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<OtelOda>(x => x.OtelOdas)
                .WithMany(x => x.OtelOdaOzelliks)
                .HasForeignKey(x => x.OtelOdaId);
        }
    }        
}
