namespace Lab1
{
    public class Contact
    {
        public int Id { get; set; }             // Уникальный идентификатор контакта
        public string Name { get; set; }        // Имя
        public string Surname { get; set; }     // Фамилия
        public string Phone { get; set; }       // Телефон
        public string Email { get; set; }       // Электронная почта

        public Contact(int id, string name, string surname, string phone, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nSurname: {Surname}\nPhone: {Phone}\nE-mail: {Email}\n";
        }
    }
}
