using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuckWithFunc
{
    public static class DanceBehaviors
    {
        public static readonly Action DanceWaltz = () => { Console.WriteLine( "Dancing waltz" ); };
        public static readonly Action DanceMinuet = () => { Console.WriteLine( "Dancing minuet" ); };
        public static readonly Action NoDance = () => { Console.WriteLine( "Im not dancing" ); };
    }
}
