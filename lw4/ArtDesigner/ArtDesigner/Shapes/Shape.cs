using ArtDesigner.Canvas;
using ArtDesigner.Primitives;

namespace ArtDesigner.Shapes
{
    public abstract class Shape : IShape
    {
        private Color _color;

        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        public Shape( Color color )
        {
            _color = color;
        }

        public abstract void Draw( ICanvas canvas );
    }
}
