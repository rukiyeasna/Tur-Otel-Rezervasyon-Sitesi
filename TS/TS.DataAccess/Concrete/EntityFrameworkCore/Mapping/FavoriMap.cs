using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class FavoriMap : IEntityTypeConfiguration<Favori>
    {
        public void Configure(EntityTypeBuilder<Favori> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<TurBilgileri>(x => x.TurBilgileris)
                .WithMany(x => x.Favoris)
                .HasForeignKey(x=>x.TurId);

            builder.HasOne<AppUser>(x => x.AppUsers)
               .WithMany(x => x.Favoris)
               .HasForeignKey(x => x.AppUserId);
        }
    }
    
}
