using System.ComponentModel.DataAnnotations;
using BidCalculation.Abstractions.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Abstractions.Dtos;
public class BidRequestDto
{
    [Required]
    [FromQuery(Name = "price")]
    [Range(1, double.MaxValue, ErrorMessage = "The vehicle base price must be greater than zero.")]
    public decimal BasePrice { get; set; }

    //TODO: add more complex logic to pattern in future for more cases
    [FromQuery(Name = "type")]
    [Required]
    [RegularExpression("Common|Luxury", ErrorMessage = "Vehicle type must be either 'Common' or 'Luxury'.")]
    public CarType Type { get; set; }
}