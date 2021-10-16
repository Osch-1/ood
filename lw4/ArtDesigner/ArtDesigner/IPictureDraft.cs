using ArtDesigner.Shapes;

namespace ArtDesigner
{
    public interface IPictureDraft
    {
        public int ShapeCount { get; }

        public IShape GetShape( int index );
    }
}