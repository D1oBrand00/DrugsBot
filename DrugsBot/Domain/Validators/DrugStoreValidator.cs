using Domain.Entities;
using FluentValidation;
using CountryData.Standard;
namespace Domain.Validators;

public class DrugStoreValidator:AbstractValidator<DrugStore>
{
    private static readonly CountryHelper helper = new CountryHelper();
    /// <summary>
    /// Валидация объекта DrugStore
    /// </summary>
    public DrugStoreValidator()
    {
        RuleFor(d => d.DrugNetwork)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.Number)
            .GreaterThan(0).WithMessage(ValidationMessage.WrongNum);
        RuleFor(d => d.Address)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        RuleFor(d => d.Address.Street)
            .Length(3, 100).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.Address.City)
            .Length(2, 50).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.Address.House)
            .Length(1, 1000).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.Address.PostalCode.ToString())
            .Length(5, 6).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.Address.Country)
            .Must((drug) => ValidCountryName(drug)).WithMessage(ValidationMessage.WrongCountryName);
            
    }
    /// <summary>
    /// Метод для проверки корректности названия страны
    /// </summary>
    /// <param name="drug"></param>
    /// <returns></returns>
    private bool ValidCountryName(string drug)
    {
        var countries = helper.GetCountries();
        return countries.Contains(drug);
        
    }
}