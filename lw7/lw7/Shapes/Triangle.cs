namespace lw7.Shapes
{
    public class Triangle : Shape
    {
        private Point _firstVertex;
        private Point _secondVertex;
        private Point _thirdVertex;

        public Triangle( Point firstVertex, Point secondVertex, Point thirdVertex )
            : base()
        {
            _firstVertex = firstVertex ?? throw new ArgumentNullException( nameof( firstVertex ) );
            _secondVertex = secondVertex ?? throw new ArgumentNullException( nameof( secondVertex ) );
            _thirdVertex = thirdVertex ?? throw new ArgumentNullException( nameof( thirdVertex ) );            

            SetFrame( CountFrame() );
        }

        public override void SetFrame( Frame frame )
        {
            base.SetFrame( frame );

        }

        private Frame CountFrame()
        {
            double frameWidth = MaxX() - MinX();
            double frameHeight = MaxY() - MinY();

            return new Frame( MinX(), MaxY(), frameWidth, frameHeight );
        }

        private double MaxX()
        {
            return VertexesXCoordinatesAsList().Max();
        }

        private double MinX()
        {
            return VertexesXCoordinatesAsList().Min();
        }

        private double MaxY()
        {
            return VertexesYCoordinatesAsList().Max();
        }

        private double MinY()
        {
            return VertexesYCoordinatesAsList().Min();
        }

        private List<double> VertexesXCoordinatesAsList()
        {
            return new() { _firstVertex.X, _secondVertex.X, _thirdVertex.X };
        }

        private List<double> VertexesYCoordinatesAsList()
        {
            return new() { _firstVertex.Y, _secondVertex.Y, _thirdVertex.Y };
        }
    }
}
