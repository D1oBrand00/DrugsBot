using Domain.Validators;
using FluentValidation;

namespace Domain.Entities
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class Country : BaseEntity
    {
        /// <summary>
        /// Конструктор для инициализации страны с названием и кодом.
        /// </summary>
        /// <param name="name">Название страны.</param>
        /// <param name="code">Код страны.</param>
        public Country(string name, string code)
        {
            Name = name;
            Code = code;
            Validate();
        }

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Код страны (например, ISO-код).
        /// </summary>
        public string Code { get; private set; }
        
        // Навигационное свойство для связи с препаратами
        public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
        /// <summary>
        /// Метод для валидации объекта Country
        /// </summary>
        /// <exception cref="ValidationException"></exception>
        private void Validate()
        {
            var validator = new CountryValidator();
            var result = validator.Validate(this);
            if (!result.IsValid)
            {
                var errors = string.Join(" ", result.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}