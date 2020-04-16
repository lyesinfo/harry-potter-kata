namespace HarryPotterKata
{
    public class Book
    {
        public double Price { get; }
        public string Volume { get; }

        public Book(string volume)
        {
            Volume = volume;
            Price = 8;
        }
    }
}
