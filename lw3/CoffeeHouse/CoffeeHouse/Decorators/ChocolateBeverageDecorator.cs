using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public class ChocolateBeverageDecorator : AbstractBeverageDecorator
    {
        private readonly int _count;

        public ChocolateBeverageDecorator( IBeverage beverage, int count )
            : base( beverage )
        {
            if ( count <= 0 )
                throw new ArgumentException( "Count can't be non positive", nameof( count ) );

            if ( count > 5 )
                throw new ArgumentException( "Count can't be more then 5", nameof( count ) );

            _count = count;
        }

        protected override double GetCondimentalCost()
        {
            return _count * 10;
        }

        protected override string GetCondimentalDescription()
        {
            return $"Chocolate bars x {_count}";
        }
    }
}
