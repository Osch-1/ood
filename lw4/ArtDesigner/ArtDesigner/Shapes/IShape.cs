namespace ArtDesigner.Shapes
{
    public interface IShape
    {
        public void Draw( ICanvas canvas );
        public Color GetColor();
    }
}
