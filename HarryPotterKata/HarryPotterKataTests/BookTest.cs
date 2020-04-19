using HarryPotterKata;
using HarryPotterKata.Discount;
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
        {   //arrange
            var book = new Book("Volume 1");
            var expected = 8;
            //act
            var actual = book.Price;
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void should_two_books_price_equals_to_16_when_they_have_the_same_volume()
        {
            //arrange 
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 1"));
            var expected = 16;
            //act
            var actual = _basket.Checkout();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void should_have_five_percent_discount_when_two_books_books_do_not_have_the_same_volume()
        {
            //arrange 
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            var expected = 16 * .95;
            //act
            var actual = _basket.Checkout();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void should_have_ten_percent_discount_when_three_books_do_not_have_the_same_volume()
        {
            //arrange 
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            var expected = 24 * .90;
            //act
            var actual = _basket.Checkout();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void should_have_fifteen_percent_discount_when_four_books_do_not_have_the_same_volume()
        {
            //arrange 
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 4"));
            var expected = 32 * .85;
            //act
            var actual = _basket.Checkout();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void should_have_twenty_percent_discount_when_four_books_do_not_have_the_same_volume()
        {
            //arrange
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 4"));
            _basket.AddBook(new Book("Volume 5"));
            var expected = 40 * .8;
            //act
            var actual = _basket.Checkout();
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void should_have_ten_percent_discount_when_three_books_do_not_have_the_same_volume_and_no_discount_for_the_last_book()
        {
            //arrange 
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 3"));
            var expected = (24 * .9) + 8;
            //act
            var actual = _basket.Checkout();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void should_have_ten_percent_discount_when_three_books_do_not_have_the_same_volume_and_no_discount_for_the_last_two_books()
        {
            //arrange 
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 3"));
            var expected = (24 * .9) + 16;
            //act
            var actual = _basket.Checkout();
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void should_create_three_sets_and_the_max_size_of_a_set_equal_to_the_number_of_strategies_to_not_get_KeyNotFoundException()
        {
            //arrange 
            _basket.AddBook(new Book("Volume 1"));
            _basket.AddBook(new Book("Volume 2"));
            _basket.AddBook(new Book("Volume 3"));
            _basket.AddBook(new Book("Volume 4"));
            _basket.AddBook(new Book("Volume 5"));
            _basket.AddBook(new Book("Volume 6"));
            _basket.AddBook(new Book("Volume 7"));
            _basket.AddBook(new Book("Volume 8"));
            _basket.AddBook(new Book("Volume 9"));
            _basket.AddBook(new Book("Volume 10"));
            _basket.AddBook(new Book("Volume 11"));
            _basket.AddBook(new Book("Volume 11"));
            var expected = (40 * .8) + (40 * .8) + 16;
            //act
            var actual = _basket.Checkout();
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
