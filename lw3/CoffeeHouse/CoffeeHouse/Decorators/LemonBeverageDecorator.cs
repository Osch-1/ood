using System;
using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public class LemonBeverageDecorator : AbstractBeverageDecorator
    {
        private const int _costPerUnit = 10;
        private readonly int _count;

        public LemonBeverageDecorator( IBeverage beverage, int count )
            : base( beverage )
        {
            if ( count < 0 )
                throw new ArgumentException( "Count can't be negative", nameof( count ) );

            _count = count;
        }

        protected override double GetCondimentalCost()
        {
            return _count * _costPerUnit;
        }

        protected override string GetCondimentalDescription()
        {
            return $"Lemon x {_count}";
        }
    }
}
