namespace Lab1
{
    public class Menu
    {
        public void DisplayMainMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. View all contacts");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. New contact");
            Console.WriteLine("4. Delete contact");
            Console.WriteLine("5. Exit");
            Console.Write("> ");
        }

        public void DisplaySearchMenu()
        {
            Console.WriteLine("Search by:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Surname");
            Console.WriteLine("3. Name and Surname");
            Console.WriteLine("4. Phone");
            Console.WriteLine("5. E-mail");
            Console.Write("> ");
        }

        public void DisplayDeleteMenu()
        {
            Console.WriteLine("Delete contact by:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Surname");
            Console.WriteLine("4. Phone");
            Console.WriteLine("5. E-mail");
            Console.Write("> ");
        }
    }
}
