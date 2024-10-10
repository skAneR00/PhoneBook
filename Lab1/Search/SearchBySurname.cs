namespace Lab1
{
    public class SearchBySurname : ISearchStrategy
    {
        public List<Contact> Search(List<Contact> contacts, string query)
        {
            return contacts.Where(c => c.Surname.ToLower().Contains(query)).ToList();
        }
    }
}
