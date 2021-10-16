using System;
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
            return _beverage.GetCost() + GetCondimentalCost();
        }

        public string GetDescription()
        {
            return $"{_beverage.GetDescription()}{Environment.NewLine}{GetCondimentalDescription()}";
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
