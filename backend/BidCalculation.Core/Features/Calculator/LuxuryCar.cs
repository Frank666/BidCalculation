using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Enums;
using BidCalculation.Abstractions.Services;
using Microsoft.Extensions.Logging;

namespace BidCalculation.Core.Features.Calculator;
public class LuxuryCar(ILogger<LuxuryCar> logger) : ICalculatorService
{
    public CarType CarType => CarType.Luxury;

    public BidResponseDto CalculatePrice(BidRequestDto bidRequestDto)
    {
        var result = new BidResponseDto();
        try
        {
            result.Price = bidRequestDto.BasePrice;
            result.BuyerFee = Math.Min(Math.Max(bidRequestDto.BasePrice * 0.10m, 25m), 200m);
            result.SpecialFee = bidRequestDto.BasePrice * 0.04m;
            result.AssociationFee = CalculatorFee.CalculateAssociationFee(bidRequestDto.BasePrice);
            result.TotalPrice = result.Price + result.BuyerFee + result.SpecialFee + result.AssociationFee + result.StorageFee;
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error calculating Luxury Car Price");
        }

        return null;
    }   
}