using System.Text.Json;

namespace Lab1
{
    public class Serializer
    {
        public string Serialize(List<Contact> contacts)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(contacts, options);
        }

        public List<Contact> Deserialize(string json)
        {
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
    }
}
