using CountryData.Standard;

namespace CountryData.Sample.CountryConsoleProject
{
    /// <summary>
    /// Main program class for demonstrating the use of the CountryData library.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Static instance of CountryHelper used throughout the program.
        /// </summary>
        private static readonly CountryHelper _helper = new CountryHelper();

        /// <summary>
        /// Entry point of the program.
        /// </summary>
        public static void Main()
        {
            // Retrieve and print all ISO codes of countries
            GetAllIsoCountryCodes();
        }

        /// <summary>
        /// Retrieves a list of all countries' ISO codes and adds them to a list.
        /// </summary>
        private static void GetAllIsoCountryCodes()
        {
            // Retrieve a list of all countries
            var countries = _helper.GetCountries();

            // Create a list to hold the ISO codes
            var isoCountryCodes = new List<string>();

            // Iterate through all countries and add their ISO codes to the list
            foreach (var country in countries)
            {
                isoCountryCodes.Add(country.CountryCode);
            }

            // Print all ISO country codes
            Console.WriteLine("ISO Country Codes:");
            foreach (var code in isoCountryCodes)
            {
                Console.WriteLine(code);
            }
        }
    }
}