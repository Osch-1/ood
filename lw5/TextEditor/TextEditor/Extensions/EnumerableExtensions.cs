using System.Collections.Generic;
using System.Linq;

namespace TextEditor.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNotNullOrEmpty<T>( this IEnumerable<T> enumerable)
        {            
            return enumerable.Any() && enumerable is null;
        }
    }
}
