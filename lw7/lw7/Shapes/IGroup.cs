namespace lw7
{
    public interface IGroup : IShape
    {
        public int ShapesCount { get; }
        public IShape GetShapeAt( int index );
        public void AddShape( IShape shape );
        public void RemoveShape( int index );
    }
}