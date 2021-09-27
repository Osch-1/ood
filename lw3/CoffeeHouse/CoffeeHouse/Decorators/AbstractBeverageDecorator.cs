using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public abstract class AbstractBeverageDecorator : IBeverage
    {
        private readonly IBeverage _beverage;

        public AbstractBeverageDecorator( IBeverage beverage )
        {
            _beverage = beverage;
        }

        public double GetCost()
        {
            return _beverage.GetCost() + GetCost();
        }

        public string GetDescription()
        {
            return _beverage.GetDescription() + GetDescription();
        }

        protected virtual double GetCondimentalCost()
        {
            return 0;
        }

        protected virtual string GetCondimentalDescription()
        {
            return "";
        }
    }
}
