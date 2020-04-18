namespace HarryPotterKata.Discount
{
    public class FifteenPercentDiscount : IDiscountStrategy
    {
        public double GetDiscount()
        {
            return .85;
        }
    }
}
