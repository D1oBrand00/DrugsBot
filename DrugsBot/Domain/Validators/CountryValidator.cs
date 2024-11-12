using FluentValidation;
using Domain.Entities;
namespace Domain.Validators;

public class CountryValidator: AbstractValidator<Country>
{
    /// <summary>
    /// Валидация объекта Country
    /// </summary>
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[A-Za-zА-Яа-яЁё\s]+$").WithMessage(ValidationMessage.WrongChars);
        RuleFor(expression: c => c.Code)
            .Length(2).WithMessage(ValidationMessage.WrongLength)
            .Matches("^[A-Z]+$").WithMessage(ValidationMessage.OnlyAZ);

    }
    
}