using System;

namespace Streams
{
    public interface IInputStream
    {
        public bool IsEnd { get; }
        public byte ReadByte();
    }

    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Hello World!" );
        }
    }
}
