using ArtDesigner.Canvas;

namespace ArtDesigner.Shapes
{
    // goes against Interface segregation principle
    public interface IGlyph
    {
        public void Draw( ICanvas canvas );
    }
}