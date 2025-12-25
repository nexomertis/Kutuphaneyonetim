namespace KutuphaneyYonetim.Models
{
    public class Kitap
    {
       public int Id { get; set; }
       public string Baslik {  get; set; }
       public string Yazar { get; set; }
       public string ISBN { get; set; }
       public int ToplamKopya { get; set; }
       public int MevcutKopya { get; set; }
       public DateTime OluşturulmaTarihi { get; set; }
        public ICollection<ÖdünçKaydı> ÖdünçKayıtları { get; set; } = new List<ÖdünçKaydı>();

    }
}
