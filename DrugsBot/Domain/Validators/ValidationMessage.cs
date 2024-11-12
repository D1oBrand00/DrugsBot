namespace Domain.Validators;

public static class ValidationMessage
{
    public static string NotNull = "{PropertyName} не может быть NULL";
    public static string NotEmpty = "{PropertyName} не может быть пустым";
    public static string WrongLength = "{PropertyName} должен быть от {MinLength} до {MaxLength} символов";
    public static string WrongChars = "{PropertyName} должно содержать только буквы, пробелы";
    public static string OnlyAZ = "{PropertyName} должно содержать только заглавные латинские буквы";
    public static string SpecialChars = "{PropertyName} не должно содержать специальные символы";
    public static string WrongCode = "{PropertyName} должно содержать только 2 заглавные латинские буквы";
    public static string WrongCountryCode = "{PropertyName} не является кодом страны";
    public static string WrongNum = "{PropertyName} должен быть положительным числом";
    public static string WrongPrecision = "{PropertyName} должен иметь не более двух знаков после запятой";
    public static string NegativeNum = "{PropertyName} не должно быть отрицательным";
    public static string WrongMax = "{PropertyName} должно быть максимум 10000";
    public static string WrongCountryName = "{PropertyName} не является названием страны";
}