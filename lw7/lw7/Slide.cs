namespace lw7
{
    public class Slide : IDrawable
    {
        private List<IShape> _shapes = new();
        private double _width;
        private double _height;
        private RGBAColor _backgroundColor = new( 0, 0, 0, 1 );

        public IReadOnlyList<IShape> Shapes => _shapes;

        public double Width => _width;

        public double Height => _height;

        public Slide( double width, double height )
        {
            _width = width;
            _height = height;
        }

        public void AddShape( IShape shape )
        {
            if ( shape is not null )
            {
                _shapes.Add( shape );
            }
        }

        public void RemoveShape( int index )
        {
            if ( index > _shapes.Count - 1 )
            {
                throw new IndexOutOfRangeException();
            }

            _shapes.RemoveAt( index );
        }

        public void Draw( ICanvas canvas )
        {
            canvas.SetFillColor( _backgroundColor.R, _backgroundColor.G, _backgroundColor.B, _backgroundColor.A );
            canvas.FillRectangle( new List<Point> { new( 0, 0 ), new( 0, Height ), new( Width, Height ), new( Width, 0 ) } );
            foreach ( var shape in _shapes )
            {
                shape.Draw( canvas );
            }
        }

        public RGBAColor GetBackgroundColor()
        {
            return _backgroundColor;
        }

        public void SetBackgroundColor( RGBAColor color )
        {
            _backgroundColor = color;
        }

        public void SetHeight( double height )
        {
            if ( height <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( height ) );
            }

            _height = height;
        }

        public void SetWidth( double width )
        {
            if ( width <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( width ) );
            }

            _width = width;
        }
    }
}
