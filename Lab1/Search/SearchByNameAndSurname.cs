namespace Lab1
{
    public class SearchByNameAndSurname : ISearchStrategy
    {
        public List<Contact> Search(List<Contact> contacts, string query)
        {
            return contacts.Where(c => c.Name.ToLower().Contains(query) && c.Surname.ToLower().Contains(query)).ToList();
        }
    }
}
