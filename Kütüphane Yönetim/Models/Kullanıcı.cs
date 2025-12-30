using System.ComponentModel.DataAnnotations;

namespace KutuphaneyYonetim.Models
{
    public class Kullanıcı
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string Şifre { get; set; }

        public bool AdminMi { get; set; } = false;
    }
}
