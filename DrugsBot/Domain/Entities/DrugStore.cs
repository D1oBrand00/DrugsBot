using System.ComponentModel.DataAnnotations;
using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// Аптека
    /// </summary>
    public class DrugStore : BaseEntity
    {
        public DrugStore(string drugNetwork, int number, Address address)
        {
            DrugNetwork = drugNetwork;
            Number = number;
            Address = address;
            Validate();
        }

        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        public string DrugNetwork { get; private set; }
        
        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }
        
        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
        /// <summary>
        /// Метод для валидации объекта DrugStore
        /// </summary>
        /// <exception cref="ValidationException"></exception>
        private void Validate()
        {
            var validator = new DrugStoreValidator();
            var result = validator.Validate(this);
            if (!result.IsValid)
            {
                var errors = string.Join(" ", result.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}