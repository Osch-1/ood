using ArtDesigner.Canvas;
using ArtDesigner.Primitives;

namespace ArtDesigner.Shapes
{
    public abstract class Shape : IGlyph
    {
        private Color _color; // сложный цвет

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
