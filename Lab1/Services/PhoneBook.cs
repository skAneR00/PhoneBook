namespace Lab1
{
    public class PhoneBook
    {
        private List<Contact> _contacts;

        public PhoneBook()
        {
            _contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public void DeleteContact(Contact contact)
        {
            _contacts.Remove(contact);
        }

        public List<Contact> SearchContacts(ISearchStrategy searchStrategy, string query)
        {
            return searchStrategy.Search(_contacts, query);
        }
    }
}
