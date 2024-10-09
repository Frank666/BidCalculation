using BidCalculation.Abstractions.Dtos;

namespace BidCalculation.Abstractions.Services;

public interface IBidService
{
    BidResponseDto GetBidByCar(BidRequestDto bidRequestDto);
}