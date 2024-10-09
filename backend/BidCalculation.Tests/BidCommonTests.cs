using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Enums;
using BidCalculation.Abstractions.Services;
using BidCalculation.Core.Features.Calculator;
using Moq;

namespace BidCalculation.Tests;

public class BidCommonTests
{
    private readonly Mock<ICalculatorService> _commonCarStrategyMock;
    private BidCalculator _bidCalculator;

    public BidCommonTests()
    {
        _commonCarStrategyMock = new Mock<ICalculatorService>();
    }

    private void Setup_Mocks_Before_Test(decimal price, decimal buyerFee, decimal specialFee, decimal associationFee, decimal totalPrice, CarType type)
    {
        _commonCarStrategyMock.Setup(s => s.CalculatePrice(It.IsAny<BidRequestDto>())).Returns(new BidResponseDto()
        {
            BuyerFee = buyerFee,
            SpecialFee = specialFee,
            AssociationFee = associationFee,
            TotalPrice = totalPrice,
            Price = price,
        });

        _commonCarStrategyMock.Setup(s => s.CarType).Returns(type);
        
        var strategies = new List<ICalculatorService> { _commonCarStrategyMock.Object };
        _bidCalculator = new BidCalculator(strategies);
    }

    [Fact]
    public void CalculateTotalPrice_ShouldReturnCorrectPrice_ForCommonCar_Case1()
    {
        Setup_Mocks_Before_Test(1000, 50, 20, 10, 1180, CarType.Common);
        // Arrange
        var bidRequest = new BidRequestDto
        {
            Type = CarType.Common,
            BasePrice = 1000
        };

        // Act
        var totalPrice = _bidCalculator.CalculateTotalPrice(bidRequest);

        // Assert
        Assert.Equal(1180, totalPrice.TotalPrice);
        _commonCarStrategyMock.Verify(s => s.CalculatePrice(It.IsAny<BidRequestDto>()), Times.Once);
    }

    [Fact]
    public void CalculateTotalPrice_ShouldReturnCorrectPrice_ForCommonCar_Case2()
    {
        Setup_Mocks_Before_Test(398, 39.80m, 7.96m, 5, 550.76m, CarType.Common);
        var vehicleData = new BidRequestDto()
        {
            BasePrice = 500,
            Type = CarType.Common
        };

        var totalPrice = _bidCalculator.CalculateTotalPrice(vehicleData);
        Assert.Equal(550.76m, totalPrice.TotalPrice);
        _commonCarStrategyMock.Verify(s => s.CalculatePrice(It.IsAny<BidRequestDto>()), Times.Once);
    }

    [Fact]
    public void CalculateTotalPrice_ShouldReturnCorrectPrice_ForCommonCar_Case3()
    {
        Setup_Mocks_Before_Test(57, 10, 1.14m, 5, 173.14m, CarType.Common);
        var vehicleData = new BidRequestDto()
        {
            BasePrice = 57,
            Type = CarType.Common
        };

        var totalPrice = _bidCalculator.CalculateTotalPrice(vehicleData);
        Assert.Equal(173.14m, totalPrice.TotalPrice);
        _commonCarStrategyMock.Verify(s => s.CalculatePrice(It.IsAny<BidRequestDto>()), Times.Once);
    }

    [Fact]
    public void CalculateTotalPrice_ShouldReturnCorrectPrice_ForCommonCar_Case4()
    {
        Setup_Mocks_Before_Test(1100, 50, 22, 15, 1287, CarType.Common);
        var vehicleData = new BidRequestDto()
        {
            BasePrice = 1100,
            Type = CarType.Common
        };

        var totalPrice = _bidCalculator.CalculateTotalPrice(vehicleData);
        Assert.Equal(1287, totalPrice.TotalPrice);
        _commonCarStrategyMock.Verify(s => s.CalculatePrice(It.IsAny<BidRequestDto>()), Times.Once);
    }

    [Fact]
    public void CalculateTotalPrice_ShouldReturnCorrectPrice_ForLuxuryCar_Check_CarType()
    {
        Setup_Mocks_Before_Test(1000000, 40000, 20, 100, 1040320, CarType.Luxury);
        // Arrange
        var bidRequest = new BidRequestDto
        {
            Type = (CarType)66,
            BasePrice = 1000000
        };

        // Assert
        var exception = Assert.Throws<ArgumentException>(() => _bidCalculator.CalculateTotalPrice(bidRequest));

        Assert.Equal("Invalid car type: No price strategy found.", exception.Message);
    }
}