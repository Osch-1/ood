using System;

namespace CoffeeHouse.Beverages
{
    public class Latte : Coffee
    {
        private readonly CoffeeType _type;

        public Latte( CoffeeType latteType )
            : base( "Latte" )
        {
            _type = latteType;
        }

        public override double GetCost()
        {
            return _type == CoffeeType.Single ? 90 : 130;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}{Environment.NewLine}Coffee type: {_type}";
        }
    }
}
