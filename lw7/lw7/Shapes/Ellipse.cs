namespace lw7.Shapes
{
    public class Ellipse : Shape
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

        public Ellipse( Point leftTop, double width, double height )
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

            _leftTop = leftTop ?? throw new ArgumentNullException( nameof( leftTop ) );
            _width = width;
            _height = height;
            SetFrame( new Frame( leftTop.X, leftTop.Y, width, height ) );
        }

        public override void SetFrame( Frame frame )
        {
            base.SetFrame( frame );
            _leftTop.X = frame.LeftTopX;
            _leftTop.Y = frame.LeftTopY;
            _width = frame.Width;
            _height = frame.Height;
        }

        public override void Draw( ICanvas canvas )
        {
            base.Draw( canvas );
            if ( BorderStyle.IsEnabled )
            {
                canvas.DrawEllipse( _leftTop, _width, _height );
            }

            if ( FillStyle.IsEnabled )
            {
                canvas.FillEllipse( _leftTop, _width, _height );
            }
        }
    }
}
