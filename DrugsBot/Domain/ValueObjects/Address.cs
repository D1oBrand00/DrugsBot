namespace Domain.ValueObjects
{
    /// <summary>
    /// Объект значения, представляющий адрес.
    /// </summary>
    public class Address : BaseValueObject
    {
        /// <summary>
        /// Конструктор для инициализации адреса.
        /// </summary>
        /// <param name="country">Страна.</param>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="house">Номер дома.</param>
        /// <param name="postalСode">Почтовый индекс.</param>
        public Address(string country, string city, string street, string house, int postalСode)
        {
            Country = country;
            City = city;
            Street = street;
            House = house;
            PostalCode = postalСode;
        }
        /// <summary>
        /// Страна
        /// </summary>
        public string Country{ get; private set; }
        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Улица.
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string House { get; private set; }
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public int PostalCode { get; private set; }
        /// <summary>
        /// Возвращает строковое представление адреса.
        /// </summary>
        /// <returns>Строка, представляющая адрес.</returns>
        public override string ToString()
        {
            return $"{Country}, {City}, {Street}, {House}, {PostalCode}";
        }
    }
}