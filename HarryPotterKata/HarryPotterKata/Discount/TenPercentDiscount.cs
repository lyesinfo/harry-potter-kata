namespace HarryPotterKata.Discount
{
    public class TenPercentDiscount : IDiscountStrategy
    {
        public double GetDiscount()
        {
            return .9;
        }
    }
}
