using ArtDesigner.Primitives;

namespace ArtDesigner.Canvas
{
    public interface ICanvas
    {
        public void SetPenColor( Color penColor );
        public void DrawLine( Point from, Point to );
        public void DrawEllipse( Point center, int width, int height );
    }
}
