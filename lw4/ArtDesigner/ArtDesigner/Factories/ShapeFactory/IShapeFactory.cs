using ArtDesigner.Shapes;

namespace ArtDesigner.Factories
{
    public interface IShapeFactory
    {
        public IShape CreateShape( string description );
    }
}
