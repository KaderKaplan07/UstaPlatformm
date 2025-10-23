// UstaPlatform.Tests/PricingEngineTests.cs
using System.Collections.Generic;
using UstaPlatform.App.Engine;
using UstaPlatform.Domain.Entities;
using UstaPlatform.Domain.Interfaces;
using Xunit;

namespace UstaPlatform.Tests
{
    // Test için SAHTE kural sınıfları oluşturuyoruz. DLL'lere ihtiyacımız yok.
    public class SahteHaftasonuKurali : IPricingRule
    {
        public string RuleName => "Sahte Hafta Sonu";
        public decimal CalculatePriceAdjustment(IsEmri workOrder)
        {
            // Test için basitçe +20 TL eklesin
            return 20.0m;
        }
    }

    public class SahteIndirimKurali : IPricingRule
    {
        public string RuleName => "Sahte İndirim";
        public decimal CalculatePriceAdjustment(IsEmri workOrder)
        {
            // Test için basitçe -10 TL indirsin
            return -10.0m;
        }
    }

    public class PricingEngineTests
    {
        [Fact]
        public void CalculatePrice_ShouldApplyAllRulesAndReturnCorrectFinalPrice()
        {
            // 1. Arrange (Hazırlık)
            // Sahte kuralları oluştur
            var kuralListesi = new List<IPricingRule>
            {
                new SahteHaftasonuKurali(), // +20 TL
                new SahteIndirimKurali()   // -10 TL
            };

            // Motoru bu sahte kurallarla başlat (Adım 0'daki düzeltme sayesinde)
            var pricingEngine = new PricingEngine(kuralListesi);

            // Test edilecek iş emri (Temel ücret 100 TL)
            var testOrder = new IsEmri { ID = 101, TemelUcret = 100.0m };

            // 2. Act (Eylem)
            decimal nihaiFiyat = pricingEngine.CalculatePrice(testOrder);

            // 3. Assert (Doğrulama)
            // Beklenen Fiyat: 100 (Temel) + 20 (Haftasonu) - 10 (İndirim) = 110
            Assert.Equal(110.0m, nihaiFiyat);
        }
    }
}