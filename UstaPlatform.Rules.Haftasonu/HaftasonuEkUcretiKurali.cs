
using System;
using UstaPlatform.Domain.Entities;
using UstaPlatform.Domain.Interfaces; 

namespace UstaPlatform.Rules.Haftasonu
{
    // IPricingRule arayüzünü uyguluyoruz
    public class HaftasonuEkUcretiKurali : IPricingRule
    {
        public string RuleName => "Hafta Sonu Ek Ücreti";

        public decimal CalculatePriceAdjustment(IsEmri workOrder)
        {
            var day = workOrder.PlanlananTarih.DayOfWeek;

            if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                // Hafta sonuysa %20 ek ücret uygula
                return workOrder.TemelUcret * 0.20m;
            }
            return 0; // Hafta içi ise 0  etki
        }
    }
}