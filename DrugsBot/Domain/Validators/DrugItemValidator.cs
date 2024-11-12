using Domain.Entities;
using FluentValidation;
namespace Domain.Validators;

public class DrugItemValidator: AbstractValidator<DrugItem>
{
    /// <summary>
    /// Валидация объекта DrugItem
    /// </summary>
    public DrugItemValidator()
    {
        RuleFor(d => d.Cost)
            .GreaterThan(0).WithMessage(ValidationMessage.WrongNum)
            .PrecisionScale(7, 2, true).WithMessage(ValidationMessage.WrongPrecision);
        RuleFor(d => d.Count)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.NegativeNum) 
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.WrongMax);  
        

    }
    
}