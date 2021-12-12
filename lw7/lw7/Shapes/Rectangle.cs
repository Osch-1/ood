namespace lw7.Shapes
{
    public class Rectangle : Shape
    {
        private Point _leftTop;
        private double _width;
        private double _height;

        public Point LeftTop
        {
            get => _leftTop;
            set
            {
                _leftTop = value ?? throw new ArgumentNullException( nameof( value ) );
                SetFrame( new( _leftTop.X, _leftTop.Y, _width, _height ) );
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                if ( _width <= 0 )
                {
                    throw new ArgumentOutOfRangeException( nameof( _width ) );
                }

                _width = value;
                SetFrame( new( _leftTop.X, _leftTop.Y, _width, _height ) );
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if ( _height <= 0 )
                {
                    throw new ArgumentOutOfRangeException( nameof( value ) );
                }

                _height = value;
                SetFrame( new( _leftTop.X, _leftTop.Y, _width, _height ) );
            }
        }

        public Point RightTop
        {
            get => new( _leftTop.X + _width, _leftTop.Y );
        }

        public Point RightBottom
        {
            get => new( RightTop.X, RightTop.Y - _height );
        }

        public Point LeftBottom
        {
            get => new( _leftTop.X, _leftTop.Y - _height );
        }

        public Rectangle( Point leftTop, double width, double height )
            : base()
        {
            if ( width <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( width ) );
            }

            if ( height <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( height ) );
            }

            _leftTop = leftTop;
            _width = width;
            _height = height;
            SetFrame( new Frame( leftTop.X, leftTop.Y, width, height ) );
        }

        public override void Draw( ICanvas canvas )
        {
            base.Draw( canvas );
            if ( BorderStyle.IsEnabled )
            {                
                canvas.DrawLine( LeftTop, RightTop );
                canvas.DrawLine( RightTop, RightBottom );
                canvas.DrawLine( RightBottom, LeftBottom );
                canvas.DrawLine( LeftBottom, LeftTop );
            }

            if ( FillStyle.IsEnabled )
            {
                canvas.FillRectangle( new List<Point> { LeftTop, RightTop, RightBottom, LeftBottom } );
            }
        }

        public override void SetFrame( Frame frame )
        {
            base.SetFrame( frame );
            _leftTop.X = frame.LeftTopX;
            _leftTop.Y = frame.LeftTopY;
            _width = frame.Width;
            _height = frame.Height;
        }
    }
}
