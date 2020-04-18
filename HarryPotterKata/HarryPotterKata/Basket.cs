using HarryPotterKata.Discount;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata
{
    public class Basket
    {
        private readonly IDictionary<int, IDiscountStrategy> _discountStrategies;
        private readonly IList<HashSet<Book>> _books;

        public Basket(IDictionary<int, IDiscountStrategy> discountStrategies)
        {
            _discountStrategies = discountStrategies;
            _books = new List<HashSet<Book>>();
        }
        public void AddBook(Book book)
        {
            var count = 0;
            var inserted = false;

            while (!inserted)
            {
                if (_books.Count == count) _books.Add(new HashSet<Book>());

                if (!_books[count].Contains(book))
                {
                    _books[count].Add(book);
                    inserted = true;
                }
                count++;
            }
        }

        public double Checkout()
        {
            double totalCost;
            try
            {
                totalCost = _books.Sum(set => GetTotalCostBeforeDiscount(set) * _discountStrategies[set.Count].GetDiscount());
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Discount strategy not implemented");
            }
            return totalCost;
        }

        private double GetTotalCostBeforeDiscount(IEnumerable<Book> books)
        {
            return books.Sum(b => b.Price);
        }
    }
}
