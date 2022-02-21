using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TS.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class TsContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JRCPL4O\\SQLEXPRESS; " +
                "database=TSProje; integrated security=true;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TurBilgileriMap());
            modelBuilder.ApplyConfiguration(new OtelBilgileriMap());
            modelBuilder.ApplyConfiguration(new SliderMap());
            modelBuilder.ApplyConfiguration(new FavoriMap());
            modelBuilder.ApplyConfiguration(new ImagesMap());
            modelBuilder.ApplyConfiguration(new RezervasyonMap());
            modelBuilder.ApplyConfiguration(new OtelMap());
            modelBuilder.ApplyConfiguration(new OtelOdaMap());
            modelBuilder.ApplyConfiguration(new OtelImageMap());
            modelBuilder.ApplyConfiguration(new OtelOdaImageMap());
            modelBuilder.ApplyConfiguration(new OtelFavoriMap());
            modelBuilder.ApplyConfiguration(new OtelOdaOzellikMap());
            modelBuilder.ApplyConfiguration(new OtelOzellikMap());
            modelBuilder.ApplyConfiguration(new OtelRezervasyonMap());
            modelBuilder.ApplyConfiguration(new MesajMap());
            modelBuilder.ApplyConfiguration(new OtelPuanMap());
            modelBuilder.ApplyConfiguration(new AdminRezervasyonMap());
            modelBuilder.ApplyConfiguration(new OtelAdminRezervasyonMap());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TurBilgileri> TurBilgileri { get; set; }
        public DbSet<OtelBilgileri> OtelBilgileri { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Favori> Favori { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Rezervasyon> Rezervasyon { get; set; }
        public DbSet<Otel> Otel { get; set; }
        public DbSet<OtelOda> OtelOda { get; set; }
        public DbSet<OtelOdaImage> OtelOdaImage { get; set; }
        public DbSet<OtelImage> OtelImage { get; set; }
        public DbSet<OtelFavori> OtelFavori { get; set; }
        public DbSet<OtelOzellik> OtelOzellik { get; set; }
        public DbSet<OtelOdaOzellik> OtelOdaOzellik { get; set; }
        public DbSet<OtelRezervasyon> OtelRezervasyon { get; set; }
        public DbSet<Mesaj> Mesaj { get; set; }
        public DbSet<OtelPuan> OtelPuan { get; set; }
        public DbSet<AdminRezervasyon> AdminRezervasyon { get; set; }
        public DbSet<OtelAdminRezervasyon> OtelAdminRezervasyon { get; set; }
    }
}
