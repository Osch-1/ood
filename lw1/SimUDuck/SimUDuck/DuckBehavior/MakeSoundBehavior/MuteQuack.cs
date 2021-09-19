using System;

namespace SimUDuck.DuckBehavior.MakeSoundBehavior
{
    public class MuteQuack : IMakeSoundBehavior
    {
        public void Quack()
        {
            Console.WriteLine( "..." );
        }
    }
}
