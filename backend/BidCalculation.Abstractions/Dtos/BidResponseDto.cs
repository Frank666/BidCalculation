namespace BidCalculation.Abstractions.Dtos;
public class BidResponseDto
{
    public decimal StorageFee { get; } = 100m;
    public decimal Price { get; set; }
    public decimal BuyerFee { get; set; }
    public decimal SpecialFee { get; set; }
    public decimal AssociationFee { get; set; }
    public decimal TotalPrice { get; set; }
}