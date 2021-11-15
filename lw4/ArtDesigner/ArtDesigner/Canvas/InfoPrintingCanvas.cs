using System;
using ArtDesigner.Primitives;

namespace ArtDesigner.Canvas
{
    public class InfoPrintingCanvas : ICanvas
    {
        public void DrawEllipse( Point center, int width, int height )
        {
            Console.WriteLine( "/////////////////////////////////////////////////////////" );
            Console.WriteLine( $"Ellipse has been drawn on {center} with W:{width} H:{height}" );
            Console.WriteLine( $"/////////////////////////////////////////////////////////{Environment.NewLine}" );
        }

        public void DrawLine( Point from, Point to )
        {
            Console.WriteLine( "/////////////////////////////////////////////////////////" );
            Console.WriteLine( $"Line drawn from {from} to {to}" );
            Console.WriteLine( $"/////////////////////////////////////////////////////////{Environment.NewLine}" );
        }

        public void SetPenColor( Color penColor )
        {
            Console.WriteLine( "/////////////////////////////////////////////////////////" );
            Console.WriteLine( $"Pen color has been set to {penColor}" );
            Console.WriteLine( $"/////////////////////////////////////////////////////////{Environment.NewLine}" );
        }
    }
}
