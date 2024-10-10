namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация компонентов
            var phoneBook = new PhoneBook();
            var contactFactory = new ContactFactory();
            var inputHandler = new InputHandler();
            var menu = new Menu();
            var searchService = new SearchService();
            var fileHandler = new FileHandler();
            var serializer = new Serializer();
            var validation = new Validation();

            // Загрузка существующих контактов из файла
            string filePath = "contacts.json";
            string jsonData = fileHandler.ReadFromFile(filePath);
            var contacts = serializer.Deserialize(jsonData);
            if (contacts.Any())
            {
                phoneBook.GetAllContacts().AddRange(contacts);
                // Обновление ContactFactory для продолжения уникальных ID
                int maxId = contacts.Max(c => c.Id);
                contactFactory.SetStartingId(maxId + 1);
            }

            bool exit = false;

            while (!exit)
            {
                menu.DisplayMainMenu();
                string choice = inputHandler.GetUserInput();

                switch (choice)
                {
                    case "1":
                        ViewAllContacts(phoneBook);
                        break;
                    case "2":
                        SearchContacts(phoneBook, searchService, inputHandler, menu);
                        break;
                    case "3":
                        AddNewContact(phoneBook, contactFactory, inputHandler, validation, fileHandler, serializer, filePath);
                        break;
                    case "4":
                        DeleteContact(phoneBook, inputHandler, menu, fileHandler, serializer, filePath);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }

                Console.WriteLine(); // Для лучшего форматирования вывода
            }
        }

        static void ViewAllContacts(PhoneBook phoneBook)
        {
            var contacts = phoneBook.GetAllContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
        }

        static void SearchContacts(PhoneBook phoneBook, SearchService searchService, InputHandler inputHandler, Menu menu)
        {
            menu.DisplaySearchMenu();
            string searchOptionInput = inputHandler.GetUserInput();

            if (!int.TryParse(searchOptionInput, out int searchOption) || searchOption < 1 || searchOption > 5)
            {
                Console.WriteLine("Invalid search option.");
                return;
            }

            string query = inputHandler.GetSearchQuery();

            var searchStrategy = searchService.GetSearchStrategy(searchOption);
            if (searchStrategy == null)
            {
                Console.WriteLine("Invalid search option.");
                return;
            }

            var results = phoneBook.SearchContacts(searchStrategy, query);

            if (results.Count == 0)
            {
                Console.WriteLine("No results found.");
            }
            else
            {
                Console.WriteLine($"Results ({results.Count}):");
                foreach (var contact in results)
                {
                    Console.WriteLine(contact);
                }
            }
        }

        static void AddNewContact(PhoneBook phoneBook, ContactFactory contactFactory, InputHandler inputHandler, Validation validation, FileHandler fileHandler, Serializer serializer, string filePath)
        {
            Console.WriteLine("New contact");
            Console.Write("Name: ");
            string name = inputHandler.GetUserInput();
            Console.Write("Surname: ");
            string surname = inputHandler.GetUserInput();

            string phone;
            do
            {
                Console.Write("Phone: ");
                phone = inputHandler.GetUserInput();
                if (!validation.IsValidPhone(phone))
                {
                    Console.WriteLine("Invalid phone number. Please enter a valid phone number.");
                }
            } while (!validation.IsValidPhone(phone));

            string email;
            do
            {
                Console.Write("E-mail: ");
                email = inputHandler.GetUserInput();
                if (!validation.IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email address. Please enter a valid email.");
                }
            } while (!validation.IsValidEmail(email));

            var newContact = contactFactory.CreateContact(name, surname, phone, email);
            phoneBook.AddContact(newContact);
            Console.WriteLine("Contact created.");

            // Сохранение в файл
            string json = serializer.Serialize(phoneBook.GetAllContacts());
            fileHandler.WriteToFile(filePath, json);
        }

        static void DeleteContact(PhoneBook phoneBook, InputHandler inputHandler, Menu menu, FileHandler fileHandler, Serializer serializer, string filePath)
        {
            menu.DisplayDeleteMenu();
            string deleteOptionInput = inputHandler.GetUserInput();

            if (!int.TryParse(deleteOptionInput, out int deleteOption) || deleteOption < 1 || deleteOption > 5)
            {
                Console.WriteLine("Invalid delete option.");
                return;
            }

            Console.Write("Enter your delete query: ");
            string query = inputHandler.GetUserInput().ToLower();

            Contact contactToDelete = null;

            switch (deleteOption)
            {
                case 1: // ID
                    if (int.TryParse(query, out int id))
                    {
                        contactToDelete = phoneBook.GetAllContacts().FirstOrDefault(c => c.Id == id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                        return;
                    }
                    break;
                case 2: // Name
                    contactToDelete = phoneBook.GetAllContacts().FirstOrDefault(c => c.Name.Equals(query, StringComparison.OrdinalIgnoreCase));
                    break;
                case 3: // Surname
                    contactToDelete = phoneBook.GetAllContacts().FirstOrDefault(c => c.Surname.Equals(query, StringComparison.OrdinalIgnoreCase));
                    break;
                case 4: // Phone
                    contactToDelete = phoneBook.GetAllContacts().FirstOrDefault(c => c.Phone.Equals(query, StringComparison.OrdinalIgnoreCase));
                    break;
                case 5: // Email
                    contactToDelete = phoneBook.GetAllContacts().FirstOrDefault(c => c.Email.Equals(query, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    Console.WriteLine("Invalid delete option.");
                    break;
            }

            if (contactToDelete != null)
            {
                phoneBook.DeleteContact(contactToDelete);
                Console.WriteLine("Contact deleted successfully.");

                // Сохранение изменений в файл
                string json = serializer.Serialize(phoneBook.GetAllContacts());
                fileHandler.WriteToFile(filePath, json);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
