using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Enums;
using BidCalculation.Abstractions.Services;

namespace BidCalculation.Core.Features.Calculator;

public class BidCalculator
{
    private readonly Dictionary<CarType, ICalculatorService> _priceStrategies;

    public BidCalculator(IEnumerable<ICalculatorService> priceStrategies)
    {
        _priceStrategies = priceStrategies.ToDictionary(ps => ps.CarType, ps => ps);
    }

    public BidResponseDto CalculateTotalPrice(BidRequestDto bidRequestDto)
    {
        var carType = bidRequestDto.Type;

        if (_priceStrategies.ContainsKey(carType))
        {
            return _priceStrategies[carType].CalculatePrice(bidRequestDto);
        }

        throw new ArgumentException("Invalid car type: No price strategy found.");
    }
}