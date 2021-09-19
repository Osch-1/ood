using System;

namespace SimUDuck.DuckBehavior.MakeSoundBehavior
{
    public class Quack : IMakeSoundBehavior
    {
        void IMakeSoundBehavior.Quack()
        {
            Console.WriteLine( "Yep quack" );
        }
    }
}
