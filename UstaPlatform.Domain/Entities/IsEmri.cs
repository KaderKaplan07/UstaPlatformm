namespace UstaPlatform.Domain.Entities
{
    // init-only özelliklerini kullanıyoruz 
    public class IsEmri
    {
        public int ID { get; init; }
        public Talep SourceTalep { get; init; }
        public Usta AtanmisUsta { get; init; }
        public DateTime PlanlananTarih { get; init; }
        public (int X, int Y) Konum { get; init; }
        public decimal TemelUcret { get; set; }
        public decimal NihaiUcret { get; set; }
    }

    public class Usta
    {
        public int ID { get; init; }
        public string Ad { get; init; }
        public string UzmanlikAlani { get; init; }
    }

    public class Vatandas
    {
        public int ID { get; init; }
        public string Ad { get; init; }
    }

    public class Talep
    {
        public int ID { get; init; }
        public Vatandas Vatandas { get; init; }
        public string Aciklama { get; init; }
        public DateTime KayitZamani { get; init; }
    }
}