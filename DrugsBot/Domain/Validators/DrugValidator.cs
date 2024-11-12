using Domain.Entities;
using FluentValidation;
using CountryData.Standard;


namespace Domain.Validators;


public class DrugValidator : AbstractValidator<Drug>
{
    private static readonly CountryHelper helper = new CountryHelper();

    /// <summary>
    /// Валидация объекта Drug
    /// </summary>
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 150).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[A-Za-zА-Яа-яЁё0-9\s]+$").WithMessage(ValidationMessage.SpecialChars);
        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[A-Za-zА-Яа-яЁё\s-]+$").WithMessage(ValidationMessage.WrongChars + " и дефисы");
        RuleFor(d => d.CountryCodeId)
            .Matches(@"^[A-Z]{2}$").WithMessage(ValidationMessage.WrongCode)
            .Must((drug) => ValidCountryCode(drug)).WithMessage(ValidationMessage.WrongCountryCode);


    }
    /// <summary>
    /// Метод для проверки корректности кода страны
    /// </summary>
    /// <param name="drug"></param>
    /// <returns></returns>
    private bool ValidCountryCode(string drug)
    {
        var countries = helper.GetCountries();
        return countries.Contains(drug);
    }
    
    

   
}