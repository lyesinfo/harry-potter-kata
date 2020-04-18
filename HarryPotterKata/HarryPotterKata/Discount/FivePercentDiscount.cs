namespace HarryPotterKata.Discount
{
    public class FivePercentDiscount : IDiscountStrategy
    {
        public double GetDiscount()
        {
            return .95;
        }
    }
}
