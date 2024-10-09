using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Services;
using BidCalculation.Core.Features.Calculator;

namespace BidCalculation.Core.Services;
public class BidService : IBidService
{
    private readonly BidCalculator _bidCalculator;

    public BidService(BidCalculator bidCalculator)
    {
        _bidCalculator = bidCalculator;
    }
    public BidResponseDto GetBidByCar(BidRequestDto bidRequestDto)
    {
        return _bidCalculator.CalculateTotalPrice(bidRequestDto);
    }
}