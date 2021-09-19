using System;

namespace SimUDuck.DuckBehavior.FlyBehavior
{
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine( "I ain't flying, dear" );
        }
    }
}
