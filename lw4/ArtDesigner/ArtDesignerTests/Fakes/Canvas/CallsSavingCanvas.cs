using System;
using System.Collections.Generic;
using ArtDesigner;
using ArtDesigner.Shapes;

namespace ArtDesignerTests.Fakes.Canvas
{
    public class CallsSavingCanvas : ICanvas
    {
        public List<string> CalledMethods = new();
        public List<Tuple<Point, Point>> SrcToDestLinePointsTuples = new();

        public void DrawEllipse( Point topLeft, int width, int height )
        {
            CalledMethods.Add( $"DrawEllipse(topleft: {topLeft.X}, {topLeft.Y} width: {width} height: {height})" );
        }

        public void DrawLine( Point from, Point to )
        {
            CalledMethods.Add( $"DrawLine(from: {from.X}, {from.Y} to: {to.X}, {to.Y})" );
            SrcToDestLinePointsTuples.Add( new( new Point( from.X, from.Y ), new Point( to.X, to.Y ) ) );
        }

        public void SetColor( Color color )
        {
            CalledMethods.Add( $"SetColor(color: {color})" );
        }
    }
}
