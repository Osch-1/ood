namespace CoffeeHouse.Beverages
{
    public abstract class Beverage : IBeverage
    {
        private readonly string _description;

        public Beverage( string description )
        {
            _description = description;
        }

        public virtual double GetCost()
        {
            return 0;
        }

        public virtual string GetDescription()
        {
            return _description;
        }
    }
}
