namespace KutuphaneyYonetim.Models
{
    public class Kullanıcı
    {
        public int Id { get; set; }
        public string Ad {  get; set; }
        public string Email { get; set; }
        public string Şifre { get; set; }
        public bool AdminMi { get; set; } = false;

    }
}
