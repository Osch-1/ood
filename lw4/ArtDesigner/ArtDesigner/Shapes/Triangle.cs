namespace ArtDesigner.Shapes
{
    public class Triangle : IShape
    {
        private Point _firstVertex;
        private Point _secondVertex;
        private Point _thirdVertex;
        private Color _color;

        public Point FirstVertex
        {
            get => _firstVertex;
        }
        public Point SecondVertex
        {
            get => _secondVertex;
        }
        public Point ThirdVertex
        {
            get => _thirdVertex;
        }

        public Triangle( Point firstVertex, Point secondVertex, Point thirdVertex, Color color )
        {
            _firstVertex = firstVertex;
            _secondVertex = secondVertex;
            _thirdVertex = thirdVertex;
            _color = color;
        }

        public void Draw( ICanvas canvas )
        {
            canvas.SetColor( GetColor() );
            canvas.DrawLine( _firstVertex, _secondVertex );
            canvas.DrawLine( _secondVertex, _thirdVertex );
            canvas.DrawLine( _thirdVertex, _firstVertex );
        }

        public Color GetColor()
        {
            return _color;
        }
    }
}
