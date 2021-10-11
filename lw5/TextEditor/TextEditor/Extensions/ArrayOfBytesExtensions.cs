using System;

namespace TextEditor.Extensions
{
    public static class ArrayOfBytesExtensions
    {
        public static ReadOnlySpan<byte> AsReadOnlySpan( this byte[] memoryRegion )
        {
            return new ReadOnlySpan<byte>( memoryRegion );
        }
    }
}
