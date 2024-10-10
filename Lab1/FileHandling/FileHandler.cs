namespace Lab1
{
    public class FileHandler
    {
        public string ReadFromFile(string path)
        {
            return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
        }

        public void WriteToFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}
