using System.ComponentModel.DataAnnotations;

namespace KutuphaneyYonetim.Models
{
    public class Üye
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin")]
        public string TelefonNumarası { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi girin")]
        public string Email { get; set; }

        public DateTime OluşturulmaTarihi { get; set; }
        public ICollection<ÖdünçKaydı> ÖdünçKayıtları { get; set; } = new List<ÖdünçKaydı>();
    }
}
