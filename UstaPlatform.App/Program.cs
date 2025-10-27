using System;
using UstaPlatform.App.Engine;
using UstaPlatform.Domain.Entities; 

Console.WriteLine(" UstaPlatform Simülasyonu ");
Console.WriteLine("========================================");

var loader = new RuleLoader();
string pluginPath = Path.Combine(AppContext.BaseDirectory, "plugins");
var yuklenenKurallar = loader.LoadRules(pluginPath);

var pricingEngine = new PricingEngine(yuklenenKurallar);

// Test Verisi Oluştur
var vatandas1 = new Vatandas { ID = 5, Ad = "Kader" };
var usta1 = new Usta { ID = 101, Ad = "Ahmet Usta", UzmanlikAlani = "Tesisat" };
var talep1 = new Talep
{
    ID = 1,
    Vatandas = vatandas1,
    Aciklama = "Mutfak musluğu sızdırıyor",
    KayitZamani = DateTime.Now
};

//  İş Emirlerini Oluştur
// BİR HAFTA SONU İŞ EMRİ
var isEmri1_Haftasonu = new IsEmri
{
    ID = 1001,
    SourceTalep = talep1,
    AtanmisUsta = usta1,
    PlanlananTarih = new DateTime(2025, 10, 25, 14, 0, 0), // Bu bir CUMARTESİ
    TemelUcret = 150.0m
};

// BİR HAFTA İÇİ İŞ EMRİ
var isEmri2_Haftaici = new IsEmri
{
    ID = 1002,
    SourceTalep = talep1,
    AtanmisUsta = usta1,
    PlanlananTarih = new DateTime(2025, 10, 23, 11, 0, 0), // Bu bir Perşembe
    TemelUcret = 120.0m
};

Console.WriteLine("\nFiyatlar Hesaplanıyor...");
pricingEngine.CalculatePrice(isEmri1_Haftasonu);
pricingEngine.CalculatePrice(isEmri2_Haftaici);