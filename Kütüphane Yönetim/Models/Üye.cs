namespace KutuphaneyYonetim.Models
{
    public class Üye
    {
         public int Id { get; set; } 
         public string Ad {  get; set; }
         public string Soyad { get; set; }
        public string TelefonNumarası { get; set; }
        public string Email { get; set; }
        public DateTime OluşturulmaTarihi { get; set; }
        public ICollection<ÖdünçKaydı> ÖdünçKayıtları { get; set; } = new List<ÖdünçKaydı>();
    }
}
