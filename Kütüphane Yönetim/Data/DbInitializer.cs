using KutuphaneyYonetim.Models;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneyYonetim.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KütüphaneDbContext context)
        {
            // Veritabanını oluştur
            context.Database.EnsureCreated();

            // Eğer zaten veri varsa çık
            if (context.Üyeler.Any())
            {
                return;
            }

            // Örnek üyeler ekle
            var üyeler = new Üye[]
            {
                new Üye { Ad = "Ahmet", Soyad = "Yılmaz", TelefonNumarası = "05551234567", Email = "ahmet@example.com", OluşturulmaTarihi = DateTime.Now },
                new Üye { Ad = "Fatma", Soyad = "Kaya", TelefonNumarası = "05559876543", Email = "fatma@example.com", OluşturulmaTarihi = DateTime.Now }
            };

            foreach (Üye u in üyeler)
            {
                context.Üyeler.Add(u);
            }
            context.SaveChanges();

            // Örnek kitaplar ekle
            var kitaplar = new Kitap[]
            {
                new Kitap { Baslik = "C# Programlama", Yazar = "Mehmet Aydın", ISBN = "978-1234567890", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "ASP.NET Core", Yazar = "Fatih Kadir", ISBN = "978-0987654321", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now }
            };

            foreach (Kitap k in kitaplar)
            {
                context.Kitaplar.Add(k);
            }
            context.SaveChanges();
        }
    }
}
