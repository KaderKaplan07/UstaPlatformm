
using System.Collections.Generic;
using UstaPlatform.App.Engine;
using UstaPlatform.Domain.Entities;
using UstaPlatform.Domain.Interfaces;
using Xunit;

namespace UstaPlatform.Tests
{
    public class SahteHaftasonuKurali : IPricingRule
    {
        public string RuleName => "Sahte Hafta Sonu";
        public decimal CalculatePriceAdjustment(IsEmri workOrder)
        {
        
            return 20.0m;
        }
    }

    public class SahteIndirimKurali : IPricingRule
    {
        public string RuleName => "Sahte İndirim";
        public decimal CalculatePriceAdjustment(IsEmri workOrder)
        {
            return -10.0m;
        }
    }

    public class PricingEngineTests
    {
        [Fact]
        public void CalculatePrice_ShouldApplyAllRulesAndReturnCorrectFinalPrice()
        {
            var kuralListesi = new List<IPricingRule>
            {
                new SahteHaftasonuKurali(),
                new SahteIndirimKurali()   
            };

            var pricingEngine = new PricingEngine(kuralListesi);

            var testOrder = new IsEmri { ID = 101, TemelUcret = 100.0m };

            decimal nihaiFiyat = pricingEngine.CalculatePrice(testOrder);

            Assert.Equal(110.0m, nihaiFiyat);
        }
    }
}