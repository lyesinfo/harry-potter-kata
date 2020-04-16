using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata
{
    public class Basket
    {
        private readonly IList<Book> _books = new List<Book>();
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public double Checkout()
        {
            var nbVolumes = _books.GroupBy(b => b.Volume).Count();
            var cost = _books.Sum(b => b.Price);
            return nbVolumes switch
            {
                2 => cost * .95,
                3 => cost * .9,
                4 => cost * .85,
                5 => cost * .8,
                _ => _books.Sum(b => b.Price),
            };
        }
    }
}
