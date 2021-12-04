namespace lw7
{
    public interface IShape : IDrawable
    {
        public Frame Frame { get; }
        public IFillStyle FillStyle { get; }
        public IBorderStyle BorderStyle { get; }
        public ICompositeShape Group { get; }
        public ICompositeShape Parent { get; set; }
        public void SetFrame( Frame frame );
    }
}