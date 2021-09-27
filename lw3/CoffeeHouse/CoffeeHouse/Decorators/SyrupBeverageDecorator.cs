using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public class SyrupBeverageDecorator : AbstractBeverageDecorator
    {
        private readonly SyrupType _syrupType;

        public SyrupBeverageDecorator( IBeverage beverage, SyrupType syrupType )
            : base( beverage )
        {
            _syrupType = syrupType;
        }

        protected override double GetCondimentalCost()
        {
            return 15;
        }

        protected override string GetCondimentalDescription()
        {
            return $"{_syrupType} syrup";
        }
    }
}
