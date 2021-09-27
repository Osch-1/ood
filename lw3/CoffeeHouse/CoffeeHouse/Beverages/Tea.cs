using System;

namespace CoffeeHouse.Beverages
{
    public class Tea : Beverage
    {
        private readonly TeaType _teaType;

        public Tea( TeaType teaType )
            : base( "Tea" )
        {
            _teaType = teaType;
        }

        public override double GetCost()
        {
            return 30;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}.{Environment.NewLine}Tea type: {_teaType}";
        }
    }
}
