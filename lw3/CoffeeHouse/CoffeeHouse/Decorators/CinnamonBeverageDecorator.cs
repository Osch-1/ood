using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public class CinnamonBeverageDecorator : AbstractBeverageDecorator
    {
        public CinnamonBeverageDecorator( IBeverage beverage )
            : base( beverage )
        {
        }

        protected override double GetCondimentalCost()
        {
            return 20;
        }

        protected override string GetCondimentalDescription()
        {
            return "Cinnamon";
        }
    }
}
