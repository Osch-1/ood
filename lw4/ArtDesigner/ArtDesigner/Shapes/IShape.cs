using ArtDesigner.Canvas;
using ArtDesigner.Primitives;

namespace ArtDesigner.Shapes
{
    public interface IShape
    {
        public Color Color { get; set; }
        public void Draw( ICanvas canvas );
    }
}