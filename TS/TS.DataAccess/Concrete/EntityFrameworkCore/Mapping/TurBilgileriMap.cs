using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class TurBilgileriMap : IEntityTypeConfiguration<TurBilgileri>
    {
        public void Configure(EntityTypeBuilder<TurBilgileri> builder)
        {
            builder.HasKey(I => I.TurId);
            builder.Property(I => I.TurId).UseIdentityColumn();

      
        }
    }
}
