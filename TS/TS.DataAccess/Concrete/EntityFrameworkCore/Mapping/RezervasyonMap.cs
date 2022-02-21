using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class RezervasyonMap : IEntityTypeConfiguration<Rezervasyon>
    {
        public void Configure(EntityTypeBuilder<Rezervasyon> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<TurBilgileri>(x => x.TurBilgileris)
                .WithMany(x => x.Rezervasyons)
                .HasForeignKey(x => x.TurId);

            builder.HasOne<AppUser>(x => x.AppUsers)
               .WithMany(x => x.Rezervasyons)
               .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<OtelBilgileri>(x => x.OtelBilgileris)
              .WithMany(x => x.Rezervasyons)
              .HasForeignKey(x => x.OtelId); 
        }
    }

}
