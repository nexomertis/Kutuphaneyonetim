using KutuphaneyYonetim.Models;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneyYonetim.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KütüphaneDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Üyeler.Any())
            {
                return;
            }

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

            var kitaplar = new Kitap[]
            {
                new Kitap { Baslik = "Alex De Souza", Yazar = "Marcos Eduardo Neves", ISBN = "978-1111111111", ResimUrl = "/images/Alex De Souza.jpg", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Biyografi", Ozet = "Fenerbahçe'nin efsane futbolcusu Alex De Souza'nın hayat hikayesi. Brezilyalı yıldızın Türkiye'deki unutulmaz yılları ve başarıları." },
                new Kitap { Baslik = "Cristoph Daum", Yazar = "Cristoph Daum", ISBN = "978-2222222222", ResimUrl = "/images/Cristoph Daum.jpg", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now, Kategori = "Biyografi", Ozet = "Alman teknik direktör Christoph Daum'un otobiyografisi. Türk futbolunda bıraktığı izler ve kariyerindeki önemli anlar." },
                new Kitap { Baslik = "Görünmez Adam", Yazar = "H.G. Wells", ISBN = "978-3333333333", ResimUrl = "/images/Görünmez Adam.jpg", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now, Kategori = "Bilim Kurgu", Ozet = "Bilim insanı Griffin'in görünmezlik formülünü keşfetmesi ve bunun trajik sonuçları. Bilim kurgunun klasik eserlerinden biri." },
                new Kitap { Baslik = "Kocaman Bir Adam", Yazar = "Barış Tut", ISBN = "978-4444444444", ResimUrl = "/images/Kocaman bir adam.jpg", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now, Kategori = "Biyografi", Ozet = "Aykut Kocaman'ın futbol kariyeri ve teknik direktörlük serüveni. Türk futbolunun önemli isimlerinden birinin hikayesi." },
                new Kitap { Baslik = "Sarı Lacivert Öfkeli Adam", Yazar = "Aytunç Erkin", ISBN = "978-5555555555", ResimUrl = "/images/sari lacivert öfkeli adam aziz yildirim.png", ToplamKopya = 6, MevcutKopya = 6, OluşturulmaTarihi = DateTime.Now, Kategori = "Spor", Ozet = "Fenerbahçe'nin efsane başkanı Aziz Yıldırım'ın hayatı ve kulübe kattıkları. Türk spor tarihinin önemli figürlerinden birinin portresi." },
                new Kitap { Baslik = "Sefiller", Yazar = "Victor Hugo", ISBN = "978-6666666666", ResimUrl = "/images/sefiller.jpg", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Klasik", Ozet = "Jean Valjean'ın kurtuluş arayışı ve 19. yüzyıl Fransa'sının toplumsal panoraması. Dünya edebiyatının en önemli eserlerinden biri." },
                new Kitap { Baslik = "Şeker Portakalı", Yazar = "Jose Mauro de Vasconcelos", ISBN = "978-7777777777", ResimUrl = "/images/Şeker Portakalı.webp", ToplamKopya = 7, MevcutKopya = 7, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "Küçük Zeze'nin yoksulluk içinde geçen çocukluğu ve hayali arkadaşı şeker portakalı ağacı. Dokunaklı bir çocukluk hikayesi." },
                new Kitap { Baslik = "Suç ve Ceza", Yazar = "Dostoyevski", ISBN = "978-8888888888", ResimUrl = "/images/Suç Ve ceza.png", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now, Kategori = "Klasik", Ozet = "Raskolnikov'un işlediği cinayetin psikolojik yükü ve vicdani hesaplaşması. Rus edebiyatının başyapıtlarından biri." },
                new Kitap { Baslik = "The Witcher", Yazar = "Andrzej Sapkowski", ISBN = "978-9999999999", ResimUrl = "/images/The witcher.jpg", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Fantastik", Ozet = "Canavar avcısı Geralt'ın karanlık bir dünyada yaşadığı maceralar. Polonyalı yazarın dünyaca ünlü fantastik serisi." },
                new Kitap { Baslik = "Yüzen Dünya", Yazar = "Axie Oh", ISBN = "978-1010101010", ResimUrl = "/images/Yüzen Dünya.jpg", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now, Kategori = "Bilim Kurgu", Ozet = "Gelecekte geçen distopik bir dünyada hayatta kalma mücadelesi. Genç yetişkin bilim kurgu türünün başarılı örneklerinden." },
                
                new Kitap { Baslik = "1984", Yazar = "George Orwell", ISBN = "978-1111111112", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now, Kategori = "Bilim Kurgu", Ozet = "Totaliter bir rejimde yaşayan Winston Smith'in özgürlük arayışı. Distopya edebiyatının en etkili eseri." },
                new Kitap { Baslik = "Dune", Yazar = "Frank Herbert", ISBN = "978-1111111113", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Bilim Kurgu", Ozet = "Çöl gezegeni Arrakis'te geçen epik bir uzay operası. Bilim kurgu edebiyatının en önemli serilerinden biri." },
                new Kitap { Baslik = "Yüzüklerin Efendisi", Yazar = "J.R.R. Tolkien", ISBN = "978-1111111114", ToplamKopya = 6, MevcutKopya = 6, OluşturulmaTarihi = DateTime.Now, Kategori = "Fantastik", Ozet = "Orta Dünya'da geçen destansı bir yolculuk. Tek Yüzük'ü yok etmek için verilen mücadele." },
                new Kitap { Baslik = "Harry Potter ve Felsefe Taşı", Yazar = "J.K. Rowling", ISBN = "978-1111111115", ToplamKopya = 8, MevcutKopya = 8, OluşturulmaTarihi = DateTime.Now, Kategori = "Fantastik", Ozet = "Genç büyücü Harry Potter'ın Hogwarts'taki ilk yılı. Büyülü dünyanın kapılarını aralayan macera." },
                new Kitap { Baslik = "Simyacı", Yazar = "Paulo Coelho", ISBN = "978-1111111116", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "Çoban Santiago'nun kişisel efsanesini gerçekleştirmek için çıktığı yolculuk. Hayallerin peşinden gitmenin hikayesi." },
                new Kitap { Baslik = "Küçük Prens", Yazar = "Antoine de Saint-Exupéry", ISBN = "978-1111111117", ToplamKopya = 7, MevcutKopya = 7, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "Küçük bir gezegenin prensi ile pilotun dostluğu. Yetişkinlerin unuttuğu değerleri hatırlatan felsefi bir masal." },
                new Kitap { Baslik = "Savaş ve Barış", Yazar = "Lev Tolstoy", ISBN = "978-1111111118", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now, Kategori = "Tarih", Ozet = "Napolyon savaşları döneminde Rus aristokrasisinin hikayesi. Dünya edebiyatının en kapsamlı romanlarından biri." },
                new Kitap { Baslik = "Anna Karenina", Yazar = "Lev Tolstoy", ISBN = "978-1111111119", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Klasik", Ozet = "Anna Karenina'nın yasak aşkı ve trajik sonu. 19. yüzyıl Rus toplumunun derinlemesine analizi." },
                new Kitap { Baslik = "Uçurtma Avcısı", Yazar = "Khaled Hosseini", ISBN = "978-1111111120", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "Afganistan'da iki çocuğun dostluğu ve yıllar sonra gelen hesaplaşma. Savaşın gölgesinde geçen dokunaklı bir hikaye." },
                new Kitap { Baslik = "Bülbülü Öldürmek", Yazar = "Harper Lee", ISBN = "978-1111111121", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "1930'ların Amerika'sında ırkçılık ve adalet teması. Avukat Atticus Finch'in adaleti savunma mücadelesi." },
                new Kitap { Baslik = "Fahrenheit 451", Yazar = "Ray Bradbury", ISBN = "978-1111111122", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Bilim Kurgu", Ozet = "Kitapların yakıldığı distopik bir gelecek. İtfaiyeci Montag'ın bilinç uyanışı ve isyanı." },
                new Kitap { Baslik = "Yeraltından Notlar", Yazar = "Dostoyevski", ISBN = "978-1111111123", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now, Kategori = "Klasik", Ozet = "Toplumdan kopmuş bir adamın iç dünyası. Varoluşçu edebiyatın öncü eserlerinden biri." },
                new Kitap { Baslik = "Çavdar Tarlasında Çocuklar", Yazar = "J.D. Salinger", ISBN = "978-1111111124", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "Genç Holden Caulfield'ın New York'ta geçirdiği üç gün. Ergenlik çağının isyankar sesi." },
                new Kitap { Baslik = "Hayvan Çiftliği", Yazar = "George Orwell", ISBN = "978-1111111125", ToplamKopya = 6, MevcutKopya = 6, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "Çiftlik hayvanlarının isyanı ve sonrası. Totaliter rejimlerin alegorik eleştirisi." },
                new Kitap { Baslik = "Cesur Yeni Dünya", Yazar = "Aldous Huxley", ISBN = "978-1111111126", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Bilim Kurgu", Ozet = "Genetik mühendisliği ile kontrol edilen bir toplum. Teknolojinin insanlığı nasıl değiştirebileceğinin uyarısı." },
                new Kitap { Baslik = "Don Kişot", Yazar = "Miguel de Cervantes", ISBN = "978-1111111127", ToplamKopya = 3, MevcutKopya = 3, OluşturulmaTarihi = DateTime.Now, Kategori = "Klasik", Ozet = "Şövalye romanlarına kafayı takmış Don Kişot'un maceraları. Modern romanın başlangıcı sayılan başyapıt." },
                new Kitap { Baslik = "Nutuk", Yazar = "Mustafa Kemal Atatürk", ISBN = "978-1111111128", ToplamKopya = 10, MevcutKopya = 10, OluşturulmaTarihi = DateTime.Now, Kategori = "Tarih", Ozet = "Atatürk'ün Kurtuluş Savaşı ve Cumhuriyet'in kuruluşunu anlattığı tarihi eser. Türk tarihinin en önemli belgelerinden." },
                new Kitap { Baslik = "Kürk Mantolu Madonna", Yazar = "Sabahattin Ali", ISBN = "978-1111111129", ToplamKopya = 6, MevcutKopya = 6, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "Raif Efendi'nin Berlin'de yaşadığı büyük aşk. Türk edebiyatının en çok okunan romanlarından biri." },
                new Kitap { Baslik = "İnce Memed", Yazar = "Yaşar Kemal", ISBN = "978-1111111130", ToplamKopya = 5, MevcutKopya = 5, OluşturulmaTarihi = DateTime.Now, Kategori = "Macera", Ozet = "Çukurova'da zulme karşı ayaklanan İnce Memed'in destanı. Anadolu'nun efsanevi kahramanının hikayesi." },
                new Kitap { Baslik = "Huzur", Yazar = "Ahmet Hamdi Tanpınar", ISBN = "978-1111111131", ToplamKopya = 4, MevcutKopya = 4, OluşturulmaTarihi = DateTime.Now, Kategori = "Roman", Ozet = "İstanbul'un ruhunu yansıtan bir aşk hikayesi. Doğu-Batı sentezinin edebiyattaki en güzel örneklerinden." }
            };

            foreach (Kitap k in kitaplar)
            {
                context.Kitaplar.Add(k);
            }
            context.SaveChanges();
        }
    }
}
