namespace CoffeeHouse.Beverages
{
    public class Coffee : Beverage
    {
        public Coffee( string description = "Coffee" )
            : base( description )
        {
        }

        public override double GetCost()
        {
            return 60;
        }
    }
}
