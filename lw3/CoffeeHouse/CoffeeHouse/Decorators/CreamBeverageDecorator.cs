using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public class CreamBeverageDecorator : AbstractBeverageDecorator
    {
        public CreamBeverageDecorator( IBeverage beverage )
            : base( beverage )
        {
        }

        protected override double GetCondimentalCost()
        {
            return 25;
        }

        protected override string GetCondimentalDescription()
        {
            return $"Cream";
        }
    }
}
