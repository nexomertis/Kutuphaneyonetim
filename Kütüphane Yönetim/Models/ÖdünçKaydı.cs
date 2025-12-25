namespace KutuphaneyYonetim.Models
{
    public class ÖdünçKaydı
    {
       public int Id { get; set; }
       public int ÜyeId { get; set; }
       public int KitapId { get; set; }
       public DateTime ÖdünçTarihi {  get; set; }
       public DateTime? İadeTarihi { get; set; }
        public Üye Üye { get; set; }
        public Kitap Kitap { get; set; }
    }
}
