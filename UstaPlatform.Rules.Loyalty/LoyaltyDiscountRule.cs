
using UstaPlatform.Domain.Entities;
using UstaPlatform.Domain.Interfaces;

namespace UstaPlatform.Rules.Loyalty
{
    public class LoyaltyDiscountRule : IPricingRule
    {
        public string RuleName => "Sadakat İndirimi (Vatandas ID < 10)";

        public decimal CalculatePriceAdjustment(IsEmri workOrder)
        {
            // Kader'in ID'si 5 olduğu için bu indirim uygulanacak
            if (workOrder.SourceTalep.Vatandas.ID < 10)
            {
                // %10 indirim (negatif ayarlama)
                return workOrder.TemelUcret * -0.10m;
            }
            return 0;
        }
    }
}