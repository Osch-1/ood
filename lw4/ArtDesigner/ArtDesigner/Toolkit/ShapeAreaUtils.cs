using ArtDesigner.Primitives;
using System.Collections.Generic;

namespace ArtDesigner.Toolkit
{
    public static class ShapeAreaUtils
    {
        public static double GetPolygonArea( IReadOnlyList<Point> points )
        {
            double area = 0;
            int j = points.Count - 1;

            for ( int i = 0; i < points.Count; i++ )
            {
                area += ( points[ j ].X + points[ i ].X ) * ( points[ j ].Y - points[ i ].Y );
                j = i;
            }

            return area / 2.0;
        }
    }
}
