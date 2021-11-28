﻿namespace lw7
{
    public static class ShapesExtensions
    {
        public static bool HasParent( this IShape context, IGroup expectedParent )
        {
            if ( context is null )
            {
                throw new ArgumentNullException( nameof( context ) );
            }

            if ( expectedParent is null )
            {
                throw new ArgumentNullException( nameof( expectedParent ) );
            }

            IGroup parent = context.Parent;

            while ( parent != null )
            {
                if ( ReferenceEquals( parent, expectedParent ) )
                {
                    return true;
                }

                parent = parent.Parent;
            }

            return false;
        }        
    }
}