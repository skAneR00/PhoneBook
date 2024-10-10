namespace Lab1
{
    public class Validation
    {
        public bool IsValidPhone(string phone)
        {
            // Базовая валидация: начинается с '+' и далее цифры, или просто цифры
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            if (phone.StartsWith("+"))
                return phone.Length > 1 && phone.Skip(1).All(char.IsDigit);
            else
                return phone.All(char.IsDigit);
        }

        public bool IsValidEmail(string email)
        {
            // Базовая валидация: содержит '@' и '.'
            return !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".");
        }
    }
}
