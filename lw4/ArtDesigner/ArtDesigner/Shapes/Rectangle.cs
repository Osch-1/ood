using System;
using ArtDesigner.Canvas;
using ArtDesigner.Primitives;

namespace ArtDesigner.Shapes
{
    public class Rectangle : Shape
    {
        private int _width;
        private int _height;

        private Point _leftTop;
        private Point _rightTop;
        private Point _rightBottom;
        private Point _leftBottom;

        public Point LeftTop
        {
            get => _leftTop;
        }

        public Point RightTop
        {
            get => _rightTop;
        }

        public Point RightBottom
        {
            get => _rightBottom;
        }

        public Point LeftBottom
        {
            get => _leftBottom;
        }

        public int Width
        {
            get => _width;
        }

        public int Height
        {
            get => _height;
        }

        public Rectangle( Color color, Point firstVertex, int width, int height )
            : base( color )
        {
            _leftTop = firstVertex;

            if ( width <= 0 )
                throw new ArgumentOutOfRangeException( "Width must greater than 0", nameof( width ) );

            if ( height <= 0 )
                throw new ArgumentOutOfRangeException( "Height myst greater than 0", nameof( height ) );

            _width = width;
            _height = height;
            _rightTop = new Point( LeftTop.X + Width, LeftTop.Y );
            _rightBottom = new Point( RightTop.X, RightTop.Y - Height );
            _leftBottom = new Point( LeftTop.X, LeftTop.Y - Height );
        }

        public void SetWidth( int width )
        {
            if ( width <= 0 )
                throw new ArgumentException( nameof( width ) );
            _width = width;

            OnWidthUpdate();
        }

        public void SetHeight( int height )
        {
            if ( height <= 0 )
                throw new ArgumentException( nameof( height ) );
            _height = height;

            OnHeightUpdate();
        }

        public override void Draw( ICanvas canvas )
        {
            canvas.SetPenColor( Color );
            canvas.DrawLine( LeftTop, RightTop );
            canvas.DrawLine( RightTop, RightBottom );
            canvas.DrawLine( RightBottom, LeftBottom );
            canvas.DrawLine( LeftBottom, LeftTop );
        }

        private void OnWidthUpdate()
        {
            _rightTop.X = LeftTop.X + Width;
            _rightBottom.X = LeftTop.X + Width;
        }

        private void OnHeightUpdate()
        {
            _leftBottom.Y = LeftTop.Y + Height;
            _rightBottom.Y = LeftTop.Y + Height;
        }
    }
}
