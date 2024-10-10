namespace Lab1
{
    public class InputHandler
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public string GetSearchQuery()
        {
            Console.Write("Enter your search query: ");
            return Console.ReadLine().ToLower();
        }

        public int GetIntegerInput(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write(prompt);
            }
            return result;
        }
    }
}
