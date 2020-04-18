using HarryPotterKata;
using HarryPotterKata.Discount;
using System;
using System.Collections.Generic;
using Xunit;

namespace HarryPotterKataTest
{
    public class BookTest
    {
        private readonly Basket _basket;
        public BookTest()
        {
            var discountStrategies = new Dictionary<int, IDiscountStrategy>
            {
                {1, new NoDiscount() },
                {2, new FivePercentDiscount() },
                {3, new TenPercentDiscount() },
                {4, new FifteenPercentDiscount() },
                {5, new TwentyPercentDiscount() },
            };
            _basket = new Basket(discountStrategies);

        }
        [Fact]
        public void should_book_price_equals_to_8_when_created()
        {
            var book = new Book("Volume 1");
            Assert.Equal(8, book.Price);
        }

        [Fact]
        public void should_two_books_price_equals_to_16_when_they_have_the_same_volume()
        {
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 1"));
            Assert.Equal(16, _basket.Checkout());
        }
        [Fact]
        public void should_have_five_percent_discount_when_two_books_books_do_not_have_the_same_volume()
        {
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            Assert.Equal(16 * .95, _basket.Checkout());
        }
        [Fact]
        public void should_have_ten_percent_discount_when_three_books_do_not_have_the_same_volume()
        {
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            Assert.Equal(24 * .90, _basket.Checkout());
        }
        [Fact]
        public void should_have_fifteen_percent_discount_when_four_books_do_not_have_the_same_volume()
        {
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 4"));
            Assert.Equal(32 * .85, _basket.Checkout());
        }
        [Fact]
        public void should_have_twenty_percent_discount_when_four_books_do_not_have_the_same_volume()
        {
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 4"));
            _basket.AddBook(new Book("Volume 5"));
            Assert.Equal(40 * .8, _basket.Checkout());
        }

        [Fact]
        public void should_throw_exception_when_select_not_implemented_strategy()
        {
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 4"));
            _basket.AddBook(new Book("Volume 5"));
            _basket.AddBook(new Book("Volume 6"));
            var exception = Assert.Throws<ArgumentException>(() => _basket.Checkout());
            Assert.Equal("Discount strategy not implemented", exception.Message);
        }
    }
}
