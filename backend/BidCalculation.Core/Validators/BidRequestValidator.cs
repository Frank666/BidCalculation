using BidCalculation.Abstractions.Dtos;
using BidCalculation.Abstractions.Enums;
using FluentValidation;

namespace BidCalculation.Core.Validators;

public class BidRequestValidator : AbstractValidator<BidRequestDto>
{
    public BidRequestValidator()
    {
        RuleFor(v => v.BasePrice)
            .GreaterThan(0).WithMessage("Base price must be greater than 0.");

        RuleFor(v => v.Type)
            .NotEmpty().WithMessage("Vehicle type is required.")
            .Must(type => type == CarType.Common || type == CarType.Luxury)
            .WithMessage("Vehicle type must be either 'Common' or 'Luxury'.");
    }
}