using FluentValidation;

namespace MinimalAPI_Weather_Browser;

public class WeatherValidator : AbstractValidator<Weather>
{
    public WeatherValidator()
    {
        RuleFor(t => t.Location)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("Value of a Location must be at least 3 characters");
        RuleFor(t => t.Temperature)
           .NotEmpty()
           .MinimumLength(1)
           .WithMessage("Value of a Location must be at least 1 characters");
        RuleFor(t => t.Wind)
           .NotEmpty()
           .MinimumLength(1)
           .WithMessage("Value of a Location must be at least 1 characters");
        RuleFor(t => t.Cloudiness)
           .NotEmpty()
           .MinimumLength(1)
           .WithMessage("Value of a Location must be at least 1 characters");
        RuleFor(t => t.Icon)
           .NotEmpty()
           .MinimumLength(1)
           .WithMessage("Value of a Location must be at least 1 characters");
    }
}