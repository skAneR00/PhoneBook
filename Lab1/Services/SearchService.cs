namespace Lab1
{
    public class SearchService
    {
        public ISearchStrategy GetSearchStrategy(int option)
        {
            return option switch
            {
                1 => new SearchByName(),
                2 => new SearchBySurname(),
                3 => new SearchByNameAndSurname(),
                4 => new SearchByPhone(),
                5 => new SearchByEmail(),
                _ => null
            };
        }
    }
}
