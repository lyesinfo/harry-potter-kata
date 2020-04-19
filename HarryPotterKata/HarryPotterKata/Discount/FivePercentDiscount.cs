namespace HarryPotterKata.Discount
{
    public class FivePercentDiscount : IDiscountStrategy
    {
        public double GetDiscount() => .95;
    }
}
