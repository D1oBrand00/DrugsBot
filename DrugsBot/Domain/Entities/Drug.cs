﻿using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization.Metadata;
using Domain.Validators;
using FluentValidation;

namespace Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат
    /// </summary>
    public class Drug : BaseEntity
    {
        public Drug(string name, string manufacturer, string countryCodeId, Country country)
        {
            Name = name;
            Manufacturer = manufacturer;
            CountryCodeId = countryCodeId;
            Country = country;
            Validate();
        }

        /// <summary>
        /// Название препарата.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Производитель препарата.
        /// </summary>
        public string Manufacturer { get; private set; }
        
        /// <summary>
        /// Код страны производителя.
        /// </summary>
        public string CountryCodeId { get; private set; }
        
        // Навигационное свойство для связи с объектом Country
        public Country Country { get; private set; }
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
        /// <summary>
        /// Метод для валидации объекта Drug
        /// </summary>
        /// <exception cref="ValidationException"></exception>

        private void Validate()
        {
            var validator = new DrugValidator();
            var result = validator.Validate(this);
            if (!result.IsValid)
            {
                var errors = string.Join(" ", result.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}