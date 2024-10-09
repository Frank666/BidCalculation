using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Features.BidCalculator.Get
{
    [ApiController]
    public static class Calculator
    {
        public static void MapBidEndpoint(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/BidCalculator");

            group.MapGet("/GetBid", ([AsParameters]BidRequestDto bidRequestDto, IBidService iBidService) =>
            {
                var bid = iBidService.GetBidByCar(bidRequestDto);
                return Results.Ok(bid);
            })
            .Produces<BidResponseDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Bid");
        }
    }
}
