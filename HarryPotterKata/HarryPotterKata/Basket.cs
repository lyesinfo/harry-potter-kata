using HarryPotterKata.Discount;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata
{
    public class Basket
    {
        private readonly IDictionary<int, IDiscountStrategy> _discountStrategies;
        private readonly IList<HashSet<Book>> _bookSets;

        public Basket(IDictionary<int, IDiscountStrategy> discountStrategies)
        {
            _discountStrategies = discountStrategies;
            _bookSets = new List<HashSet<Book>>();
        }

        public void AddBook(Book book)
        {
            var setIndex = 0;
            var inserted = false;

            while (!inserted)
            {
                if (_bookSets.Count <= setIndex) _bookSets.Add(new HashSet<Book>());

                if (!_bookSets[setIndex].Contains(book) && _bookSets[setIndex].Count < _discountStrategies.Count)
                {
                    _bookSets[setIndex].Add(book);
                    inserted = true;
                }
                setIndex++;
            }
        }

        public double Checkout() => _bookSets.Sum(set =>
                GetTotalCostBeforeDiscount(set) * _discountStrategies[set.Count].GetDiscount());

        private double GetTotalCostBeforeDiscount(IEnumerable<Book> books) => books.Sum(b => b.Price);
    }

}
