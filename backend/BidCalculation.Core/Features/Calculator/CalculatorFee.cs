namespace BidCalculation.Core.Features.Calculator;
public class CalculatorFee
{
    public static decimal CalculateAssociationFee(decimal basePrice)
    {
        if (basePrice <= 500) return 5;
        if (basePrice <= 1000) return 10;
        if (basePrice <= 3000) return 15;
        return 20;
    }
}
