namespace lw7
{
    public interface ISlide : IDrawable
    {
        public IReadOnlyList<IShape> Shapes { get; }
        public double Width { get; }
        public double Height { get; }
        public void AddShape( IShape shape );
        public void RemoveShape( int index );
        public void SetWidth( double width );
        public void SetHeight( double height );
        public IRGBAColor GetColor();
        public void SetBackgroundColor( IRGBAColor color );
    }
}
