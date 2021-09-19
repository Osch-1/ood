using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuckWithFunc
{
    public static class MakeSoundBehaviors
    {
        public static readonly Action Quack = () => { Console.WriteLine( "Quack" ); };
        public static readonly Action Squeak = () => { Console.WriteLine( "Squeak" ); };
        public static readonly Action MuteQuack = () => { Console.WriteLine( "..." ); };
    }
}
