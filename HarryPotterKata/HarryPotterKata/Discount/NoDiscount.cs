namespace HarryPotterKata.Discount
{
    public class NoDiscount : IDiscountStrategy
    {
        public double GetDiscount()
        {
            return 1;
        }
    }
}
