namespace lw7
{
    public interface IShape : IDrawable
    {
        public Frame Frame { get; }
        public IFillStyle FillStyle { get; }
        public IBorderStyle BorderStyle { get; }
        public IGroup Group { get; }
        public IGroup Parent { get; set; }
        public void SetFrame( Frame frame );
    }
}