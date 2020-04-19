namespace HarryPotterKata.Discount
{
    public class NoDiscount : IDiscountStrategy
    {
        public double GetDiscount() => 1;
    }
}
