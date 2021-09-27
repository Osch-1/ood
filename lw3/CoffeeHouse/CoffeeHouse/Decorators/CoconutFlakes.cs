using System;
using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public class CoconutFlakes : AbstractBeverageDecorator
    {
        private const int _costPerGramm = 1;
        private readonly int _mass;

        public CoconutFlakes( IBeverage beverage, int mass )
            : base( beverage )
        {
            if ( mass < 0 )
                throw new ArgumentException( "Mass can't be negative", nameof( mass ) );

            _mass = mass;
        }

        protected override double GetCondimentalCost()
        {
            return _mass * _costPerGramm;
        }

        protected override string GetCondimentalDescription()
        {
            return $"Coconut flakes: {_mass}g";
        }
    }
}
