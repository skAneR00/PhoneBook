namespace Lab1
{
    public class SearchByPhone : ISearchStrategy
    {
        public List<Contact> Search(List<Contact> contacts, string query)
        {
            return contacts.Where(c => c.Phone.Contains(query)).ToList();
        }
    }
}
