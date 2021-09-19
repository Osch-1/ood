using System;

namespace SimUDuck.DuckBehavior.MakeSoundBehavior
{
    public class Squeak : IMakeSoundBehavior
    {
        public void Quack()
        {
            Console.WriteLine( "Qua..  squeak!" );
        }
    }
}
