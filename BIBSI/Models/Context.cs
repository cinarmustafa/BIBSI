using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BIBSI.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=bibsiDb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<IsArayan>().ToTable("IsArayanlar", "dbo");
            modelBuilder.Entity<IsVeren>().ToTable("IsVerenler", "dbo");
            modelBuilder.Entity<Fotograf>().ToTable("Fotograflar", "dbo");
            modelBuilder.Entity<Ilan>().ToTable("Ilanlar", "dbo");
            modelBuilder.Entity<Basvuru>().ToTable("Basvurular", "dbo");
            modelBuilder.Entity<Sehir>().ToTable("Sehirler", "dbo");
            modelBuilder.Entity<Ilce>().ToTable("Ilceler", "dbo");
            modelBuilder.Entity<Mahalle>().ToTable("Mahalleler", "dbo");
            modelBuilder.Entity<Meslek>().ToTable("Meslekler", "dbo");
            modelBuilder.Entity<Pozisyon>().ToTable("Pozisyonlar", "dbo");
            modelBuilder.Entity<Sektor>().ToTable("Sektorler", "dbo");
            modelBuilder.Entity<Sirket>().ToTable("Sirketler", "dbo");
            modelBuilder.Entity<IsDeneyimi>().ToTable("IsDeneyimleri", "dbo");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<IsArayan> IsArayanlar { get; set; }
        public DbSet<IsVeren> IsVerenler { get; set; }
        public DbSet<Fotograf> Fotograflar { get; set; }
        public DbSet<Ilan> Ilanlar { get; set; }
        public DbSet<Basvuru> Basvurular { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Mahalle> Mahalleler { get; set; }
        public DbSet<Meslek> Meslekler { get; set; }
        public DbSet<Pozisyon> Pozisyonlar { get; set; }
        public DbSet<Sektor> Sektorler { get; set; }
        public DbSet<Sirket> Sirketler { get; set; }
        public DbSet<IsDeneyimi> IsDeneyimleri { get; set; }
    }
}