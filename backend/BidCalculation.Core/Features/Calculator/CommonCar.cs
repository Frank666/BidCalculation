using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Enums;
using BidCalculation.Abstractions.Services;
using Microsoft.Extensions.Logging;

namespace BidCalculation.Core.Features.Calculator;
public class CommonCar(ILogger<CommonCar> logger) : ICalculatorService
{
    public CarType CarType => CarType.Common;
    public BidResponseDto CalculatePrice(BidRequestDto bidRequestDto)
    {
        var result = new BidResponseDto();
        try
        {
            result.Price = bidRequestDto.BasePrice;
            result.BuyerFee = Math.Min(Math.Max(bidRequestDto.BasePrice * 0.10m, 10m), 50m);
            result.SpecialFee = bidRequestDto.BasePrice * 0.02m;
            result.AssociationFee = CalculatorFee.CalculateAssociationFee(bidRequestDto.BasePrice);
            result.TotalPrice = result.Price + result.BuyerFee + result.SpecialFee + result.AssociationFee + result.StorageFee;
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error calculating Common Car Price");
        }

        return null;
    }
}