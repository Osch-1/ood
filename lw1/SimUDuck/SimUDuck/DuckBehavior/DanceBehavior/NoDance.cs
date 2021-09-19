using System;

namespace SimUDuck.DuckBehavior.DanceBehavior
{
    public class NoDance : IDanceBehavior
    {
        public void Dance()
        {
            Console.WriteLine( "Sorry, dear, I'm not dancing" );
        }
    }
}
