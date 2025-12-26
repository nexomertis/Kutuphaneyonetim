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
                new Kitap { Baslik = "Alex De Souza", Yazar = "Marcos Eduardo Neves", ISBN = "978-1111111111", ResimUrl = "/images/Alex De Souza.jpg", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "Cristoph Daum", Yazar = "Cristoph Daum", ISBN = "978-2222222222", ResimUrl = "/images/Cristoph Daum.jpg", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "Görünmez Adam", Yazar = "H.G. Wells", ISBN = "978-3333333333", ResimUrl = "/images/Görünmez Adam.jpg", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "Kocaman Bir Adam", Yazar = "Barış Tut", ISBN = "978-4444444444", ResimUrl = "/images/Kocaman bir adam.jpg", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "Sarı Lacivert Öfkeli Adam", Yazar = "Aytunç Erkin", ISBN = "978-5555555555", ResimUrl = "/images/sari lacivert öfkeli adam aziz yildirim.png", ToplamKopya = 6, MevcutKopya = 6, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "Sefiller", Yazar = "Victor Hugo", ISBN = "978-6666666666", ResimUrl = "/images/sefiller.jpg", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "Şeker Portakalı", Yazar = "Jose Mauro de Vasconcelos", ISBN = "978-7777777777", ResimUrl = "/images/Şeker Portakalı.webp", ToplamKopya = 7, MevcutKopya = 7, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "Suç ve Ceza", Yazar = "Dostoyevski", ISBN = "978-8888888888", ResimUrl = "/images/Suç Ve ceza.png", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "The Witcher", Yazar = "Andrzej Sapkowski", ISBN = "978-9999999999", ResimUrl = "/images/The witcher.jpg", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now },
                new Kitap { Baslik = "Yüzen Dünya", Yazar = "Axie Oh", ISBN = "978-1010101010", ResimUrl = "/images/Yüzen Dünya.jpg", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now }
            };

            foreach (Kitap k in kitaplar)
            {
                context.Kitaplar.Add(k);
            }
            context.SaveChanges();
        }
    }
}
