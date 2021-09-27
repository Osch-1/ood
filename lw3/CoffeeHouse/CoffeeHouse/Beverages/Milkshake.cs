using System;

namespace CoffeeHouse.Beverages
{
    public class Milkshake : Beverage
    {
        private readonly MilkshakeType _milkshakeType;

        public Milkshake( MilkshakeType milkshakeType )
            : base( "Milkshake" )
        {
            _milkshakeType = milkshakeType;
        }

        public override double GetCost()
        {
            return 80;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}{Environment.NewLine}Milkshake type: {_milkshakeType}";
        }
    }
}
