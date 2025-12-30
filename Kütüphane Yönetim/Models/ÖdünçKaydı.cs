namespace KutuphaneyYonetim.Models
{
    public class ÖdünçKaydı
    {
       public int Id { get; set; }
       public int ÜyeId { get; set; }
       public int KitapId { get; set; }
       public DateTime ÖdünçTarihi {  get; set; }
       public DateTime SonİadeTarihi { get; set; }
       public DateTime? İadeTarihi { get; set; }
        public Üye Üye { get; set; }
        public Kitap Kitap { get; set; }

        public bool GecikmisMi => İadeTarihi == null && DateTime.Now > SonİadeTarihi;
        public int GecikmeGunu => İadeTarihi == null && DateTime.Now > SonİadeTarihi 
            ? Math.Max(1, (int)(DateTime.Now - SonİadeTarihi).TotalDays)
            : 0;
        public int GecikmeDakika => İadeTarihi == null && DateTime.Now > SonİadeTarihi 
            ? (int)(DateTime.Now - SonİadeTarihi).TotalMinutes
            : 0;
    }
}
