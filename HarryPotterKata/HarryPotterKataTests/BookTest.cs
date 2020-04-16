using HarryPotterKata;
using Xunit;

namespace HarryPotterKataTest
{
    public class BookTest
    {
        [Fact]
        public void should_book_price_equals_to_8_when_created()
        {
            var book = new Book("Volume 1");
            Assert.Equal(8, book.Price);
        }

        [Fact]
        public void should_two_books_price_equals_to_16_when_they_have_the_same_volume()
        {
            var basket = new Basket();
            basket.AddBook(new Book("Volume 1"));
            basket.AddBook(new Book("Volume 1"));
            Assert.Equal(16, basket.Checkout());
        }
        [Fact]
        public void should_have_five_percent_discount_when_two_books_dont_have_the_volume()
        {
            var basket = new Basket();
            basket.AddBook(new Book("Volume 1"));
            basket.AddBook(new Book("Volume 2"));
            Assert.Equal(16 * .95, basket.Checkout());
        }
        [Fact]
        public void should_have_ten_percent_discount_when_three_books_dont_have_the_volume()
        {
            var basket = new Basket();
            basket.AddBook(new Book("Volume 1"));
            basket.AddBook(new Book("Volume 2"));
            basket.AddBook(new Book("Volume 3"));
            Assert.Equal(24 * .90, basket.Checkout());
        }
        [Fact]
        public void should_have_fifteen_percent_discount_when_four_books_dont_have_the_volume()
        {
            var basket = new Basket();
            basket.AddBook(new Book("Volume 1"));
            basket.AddBook(new Book("Volume 2"));
            basket.AddBook(new Book("Volume 3"));
            basket.AddBook(new Book("Volume 4"));
            Assert.Equal(32 * .85, basket.Checkout());
        }
        [Fact]
        public void should_have_twenty_percent_discount_when_four_books_dont_have_the_volume()
        {
            var basket = new Basket();
            basket.AddBook(new Book("Volume 1"));
            basket.AddBook(new Book("Volume 2"));
            basket.AddBook(new Book("Volume 3"));
            basket.AddBook(new Book("Volume 4"));
            basket.AddBook(new Book("Volume 5"));
            Assert.Equal(40 * .8, basket.Checkout());
        }
    }
}
