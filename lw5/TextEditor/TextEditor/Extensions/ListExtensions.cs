﻿using System.Collections.Generic;
using System.Linq;

namespace TextEditor.Extensions
{
    public static class ListExtensions
    {
        public static void Resize<T>( this List<T> list, int sz, T c = default( T ) )
        {
            int cur = list.Count;
            if ( sz < cur )
                list.RemoveRange( sz, cur - sz );
            else if ( sz > cur )
                list.AddRange( Enumerable.Repeat( c, sz - cur ) );
        }
    }
}
