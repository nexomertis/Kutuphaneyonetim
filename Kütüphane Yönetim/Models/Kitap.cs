using System.ComponentModel.DataAnnotations;

namespace KutuphaneyYonetim.Models
{
    public class Kitap
    {
       public int Id { get; set; }

       [Required(ErrorMessage = "Kitap başlığı zorunludur")]
       [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir")]
       public string Baslik {  get; set; }

       [Required(ErrorMessage = "Yazar adı zorunludur")]
       [StringLength(100, ErrorMessage = "Yazar adı en fazla 100 karakter olabilir")]
       public string Yazar { get; set; }

       [Required(ErrorMessage = "ISBN zorunludur")]
       public string ISBN { get; set; }

       public string? ResimUrl { get; set; }

       [Range(1, 1000, ErrorMessage = "Toplam kopya 1-1000 arasında olmalı")]
       public int ToplamKopya { get; set; }

       [Range(0, 1000, ErrorMessage = "Mevcut kopya 0-1000 arasında olmalı")]
       public int MevcutKopya { get; set; }

       [StringLength(50, ErrorMessage = "Kategori en fazla 50 karakter olabilir")]
       public string? Kategori { get; set; }

       [StringLength(1000, ErrorMessage = "Özet en fazla 1000 karakter olabilir")]
       public string? Ozet { get; set; }

       public DateTime OluşturulmaTarihi { get; set; }
       public ICollection<ÖdünçKaydı> ÖdünçKayıtları { get; set; } = new List<ÖdünçKaydı>();
    }
}
