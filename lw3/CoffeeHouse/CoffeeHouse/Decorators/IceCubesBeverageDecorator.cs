using System;
using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public class IceCubesBeverageDecorator : AbstractBeverageDecorator
    {
        private readonly IceCubeType _type;
        private readonly int _count;

        public IceCubesBeverageDecorator( IBeverage beverage, IceCubeType type, int count )
            : base( beverage )
        {
            if ( count < 0 )
                throw new ArgumentException( "Count can't be negative", nameof( count ) );

            _type = type;
            _count = count;
        }

        protected override double GetCondimentalCost()
        {
            return _count * ( _type == IceCubeType.Dry ? 10 : 5 );
        }

        protected override string GetCondimentalDescription()
        {
            return $"{_type} ice cubes x {_count}";
        }
    }
}
