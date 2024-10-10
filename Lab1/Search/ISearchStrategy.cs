namespace Lab1
{
    public interface ISearchStrategy
    {
        List<Contact> Search(List<Contact> contacts, string query);
    }
}
