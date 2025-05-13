using Microsoft.EntityFrameworkCore;

namespace HelloMVC.Models
{
    public class OkulDbContes:DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-E24Q7EP8\SQLEXPRESS;Initial Catalog=OkulDbBilisim;Integrated Security=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();

            //fluent API
        }
    }
}

