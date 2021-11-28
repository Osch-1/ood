namespace lw7.Shapes
{
    public class Ellipse : Shape
    {
        private readonly Point _leftTop;
        private readonly double _width;
        private readonly double _height;

        public Ellipse( Point leftTop, double width, double height )
        {
            _leftTop = leftTop;
            _width = width;
            _height = height;
        }

        //extract strategy?
        public override void Draw( ICanvas canvas )
        {
            canvas.DrawEllipse( _leftTop, _width, _height );
            canvas.FillEllipse( _leftTop, _width, _height );
        }
    }
}
