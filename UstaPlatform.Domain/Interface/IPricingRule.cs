using UstaPlatform.Domain.Entities; 
namespace UstaPlatform.Domain.Interfaces
{
    public interface IPricingRule
    {
        string RuleName { get; }
        decimal CalculatePriceAdjustment(IsEmri workOrder);
    }
}