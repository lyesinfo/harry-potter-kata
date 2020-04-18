using HarryPotterKata.Discount;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata
{
    public class Basket
    {
        private readonly IDictionary<int, IDiscountStrategy> _discountStrategies;

        public Basket(IDictionary<int, IDiscountStrategy> discountStrategies)
        {
            _discountStrategies = discountStrategies;
        }
        private readonly IList<Book> _books = new List<Book>();
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public double Checkout()
        {
            var numberDistinctVolumes = GetNumberDistinctVolumes();
            if (!_discountStrategies.ContainsKey(numberDistinctVolumes))
                throw new ArgumentException("Discount strategy not implemented");
            return GetTotalCostBeforeDiscount() * _discountStrategies[numberDistinctVolumes].GetDiscount();
        }

        private double GetTotalCostBeforeDiscount()
        {
            return _books.Sum(b => b.Price);
        }

        private int GetNumberDistinctVolumes()
        {
            return _books.GroupBy(b => b.Volume).Count();
        }
    }
}
