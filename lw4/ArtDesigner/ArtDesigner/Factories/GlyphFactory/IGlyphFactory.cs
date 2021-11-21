using ArtDesigner.Shapes;

namespace ArtDesigner.Factories
{
    public interface IGlyphFactory
    {
        public IGlyph Create( string description );
    }
}
