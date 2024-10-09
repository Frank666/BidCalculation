using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Enums;

namespace BidCalculation.Abstractions.Services;

public interface ICalculatorService
{
    CarType CarType { get; }
    BidResponseDto CalculatePrice(BidRequestDto bidRequestDto);
}