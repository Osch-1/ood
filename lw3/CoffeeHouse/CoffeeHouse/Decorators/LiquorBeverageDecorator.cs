using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeHouse.Beverages;

namespace CoffeeHouse.Decorators
{
    public enum LiquorType : byte
    {
        Walnut = 0,
        Chocolate = 1
    }

    public class LiquorBeverageDecorator : AbstractBeverageDecorator
    {
        private readonly LiquorType _liquorType;

        public LiquorBeverageDecorator( IBeverage beverage, LiquorType liquorType )
            : base( beverage )
        {
            _liquorType = liquorType;
        }

        protected override double GetCondimentalCost()
        {
            return 50;
        }

        protected override string GetCondimentalDescription()
        {
            return $"{_liquorType} liquor";
        }
    }
}
