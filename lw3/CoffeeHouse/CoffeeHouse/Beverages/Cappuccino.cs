using System;

namespace CoffeeHouse.Beverages
{
    public class Cappuccino : Coffee
    {
        private readonly CoffeeType _type;

        public Cappuccino( CoffeeType coffeeType )
            : base( "Cappucino" )
        {
            _type = coffeeType;
        }

        public override double GetCost()
        {
            return _type == CoffeeType.Single ? 80 : 120;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}{Environment.NewLine}Coffee type: {_type}";
        }
    }
}
