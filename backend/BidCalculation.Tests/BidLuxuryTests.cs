using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Enums;
using BidCalculation.Abstractions.Services;
using BidCalculation.Core.Features.Calculator;
using Moq;

namespace BidCalculation.Tests;

public class BidLuxuryTests
{
    private readonly Mock<ICalculatorService> _luxuryCarStrategyMock;
    private BidCalculator _bidCalculator;

    public BidLuxuryTests()
    {
        _luxuryCarStrategyMock = new Mock<ICalculatorService>();
    }

    private void Setup_Mocks_Before_Test(decimal price, decimal buyerFee, decimal specialFee, decimal associationFee, decimal totalPrice, CarType type)
    {
        _luxuryCarStrategyMock.Setup(s => s.CalculatePrice(It.IsAny<BidRequestDto>())).Returns(new BidResponseDto()
        {
            BuyerFee = buyerFee,
            SpecialFee = specialFee,
            AssociationFee = associationFee,
            TotalPrice = totalPrice,
            Price = price,
        });

        _luxuryCarStrategyMock.Setup(s => s.CarType).Returns(type);

        var strategies = new List<ICalculatorService> { _luxuryCarStrategyMock.Object };
        _bidCalculator = new BidCalculator(strategies);
    }

    [Fact]
    public void CalculateTotalPrice_ShouldReturnCorrectPrice_ForLuxuryCar_Case1()
    {
        Setup_Mocks_Before_Test(1800, 180, 72, 15, 2167, CarType.Luxury);
        // Arrange
        var bidRequest = new BidRequestDto
        {
            Type = CarType.Luxury,
            BasePrice = 1800
        };

        // Act
        var totalPrice = _bidCalculator.CalculateTotalPrice(bidRequest);

        // Assert
        Assert.Equal(2167, totalPrice.TotalPrice);
        _luxuryCarStrategyMock.Verify(s => s.CalculatePrice(It.IsAny<BidRequestDto>()), Times.Once);
    }

    [Fact]
    public void CalculateTotalPrice_ShouldReturnCorrectPrice_ForLuxuryCar_Case2()
    {
        Setup_Mocks_Before_Test(1000000, 40000, 20, 100, 1040320, CarType.Luxury);
        // Arrange
        var bidRequest = new BidRequestDto
        {
            Type = CarType.Luxury,
            BasePrice = 1000000
        };

        // Act
        var totalPrice = _bidCalculator.CalculateTotalPrice(bidRequest);

        // Assert
        Assert.Equal(1040320, totalPrice.TotalPrice);
        _luxuryCarStrategyMock.Verify(s => s.CalculatePrice(It.IsAny<BidRequestDto>()), Times.Once);
    }

    [Fact]
    public void CalculateTotalPrice_ShouldReturnCorrectPrice_ForLuxuryCar_Check_CarType()
    {
        Setup_Mocks_Before_Test(1000000, 40000, 20, 100, 1040320, CarType.Luxury);
        // Arrange
        var bidRequest = new BidRequestDto
        {
            Type = (CarType)99,
            BasePrice = 1000000
        };

        // Assert
        var exception = Assert.Throws<ArgumentException>(() => _bidCalculator.CalculateTotalPrice(bidRequest));

        Assert.Equal("Invalid car type: No price strategy found.", exception.Message);
    }
}