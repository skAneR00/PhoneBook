namespace Lab1
{
    public class SearchByName : ISearchStrategy
    {
        public List<Contact> Search(List<Contact> contacts, string query)
        {
            return contacts.Where(c => c.Name.ToLower().Contains(query)).ToList();
        }
    }
}
