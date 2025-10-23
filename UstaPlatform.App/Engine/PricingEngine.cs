
using System.Collections.Generic;
using UstaPlatform.Domain.Entities;
using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.App.Engine
{
    public class PricingEngine
    {
        private readonly List<IPricingRule> _rules;

        public PricingEngine(List<IPricingRule> rules)
        {
            _rules = rules;
            Console.WriteLine($"[Engine] Fiyat motoru {_rules.Count} kural ile başlatıldı.");
        }

        public decimal CalculatePrice(IsEmri workOrder)
        {
            decimal finalPrice = workOrder.TemelUcret;
            Console.WriteLine($"--- Fiyat Hesaplanıyor (İş Emri: {workOrder.ID}) ---");
            Console.WriteLine($"Temel Ücret: {finalPrice:C}");

            foreach (var rule in _rules)
            {
                decimal adjustment = rule.CalculatePriceAdjustment(workOrder);
                finalPrice += adjustment;
                if (adjustment != 0)
                    Console.WriteLine($"Kural ({rule.RuleName}) uygulandı: {adjustment:C}");
            }

            workOrder.NihaiUcret = finalPrice;
            Console.WriteLine($"NİHAİ ÜCRET: {finalPrice:C}");
            Console.WriteLine("-----------------------------------");
            return finalPrice;
        }
    }
}