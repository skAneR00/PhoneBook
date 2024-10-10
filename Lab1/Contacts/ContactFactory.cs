namespace Lab1
{
    public class ContactFactory
    {
        private int _nextId = 1;  // Переменная для хранения следующего уникального ID

        public Contact CreateContact(string name, string surname, string phone, string email)
        {
            // Создаем новый контакт с уникальным ID
            var contact = new Contact(_nextId, name, surname, phone, email);
            _nextId++;
            return contact;
        }

        // Метод для установки начального ID, чтобы избежать дублирования
        public void SetStartingId(int startingId)
        {
            if (startingId >= _nextId)
            {
                _nextId = startingId;
            }
        }

        public ContactFactory()
        {
            // Конструктор по умолчанию
        }

        public ContactFactory(int startingId)
        {
            _nextId = startingId;
        }
    }
}
