using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuckWithFunc
{
    public static class FlyBehaviors
    {
        public static readonly Action FlyWithWings = () =>
        {
            Console.WriteLine( "Fly with wings" );
        };
        public static readonly Action FlyNoWay = () => { Console.WriteLine( "Im not flying" ); };
    }
}
