using ArtDesigner.Shapes;

namespace ArtDesigner
{
    public interface IShapeFactory
    {
        public IShape GetShape( string description );
    }
}
