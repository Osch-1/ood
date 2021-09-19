using System;
using System.Collections.Generic;

namespace SimUDuck
{
    class Program
    {
        static void Main()
        {
            List<Duck> ducks = new()
            {
                new Duck(),
                new DecoyDuck(),
                new MallardDuck(),
                new RedheadDuck()
            };

            ducks.ForEach( d =>
            {
                Console.WriteLine( $"{d.GetType()} performs actions:" );
                d.Dance();
                d.Draw();
                d.Fly();
                d.Fly();
                d.Fly();
                d.Swim();
                Console.WriteLine( $"{d.GetType()}s performance ended.\n" );
            } );
        }
    }
}
