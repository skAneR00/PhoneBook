namespace Lab1
{
    public class SearchByEmail : ISearchStrategy
    {
        public List<Contact> Search(List<Contact> contacts, string query)
        {
            return contacts.Where(c => c.Email.ToLower().Contains(query)).ToList();
        }
    }
}
