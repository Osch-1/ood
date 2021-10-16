using ArtDesigner.Shapes;

namespace ArtDesigner
{
    public interface ICanvas
    {
        public void SetColor( Color color );
        public void DrawLine( Point from, Point to );
        public void DrawEllipse( Point topLeft, int width, int height );
    }
}