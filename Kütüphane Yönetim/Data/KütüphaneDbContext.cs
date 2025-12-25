using Microsoft.EntityFrameworkCore;
using KutuphaneyYonetim.Models;

namespace KutuphaneyYonetim.Data
{
    public class KütüphaneDbContext : DbContext
    {
        public KütüphaneDbContext(DbContextOptions<KütüphaneDbContext> options) : base(options)
        {
        }

        public DbSet<Üye> Üyeler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<ÖdünçKaydı> ÖdünçKayıtları { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ÖdünçKaydı>()
                .HasOne(o => o.Üye)
                .WithMany(u => u.ÖdünçKayıtları)
                .HasForeignKey(o => o.ÜyeId);

            modelBuilder.Entity<ÖdünçKaydı>()
                .HasOne(o => o.Kitap)
                .WithMany(k => k.ÖdünçKayıtları)
                .HasForeignKey(o => o.KitapId);
        }
    }
}
