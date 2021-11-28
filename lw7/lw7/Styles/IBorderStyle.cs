namespace lw7
{
    public interface IBorderStyle : IStyle, IEquatable<IBorderStyle>
    {        
        public double BorderHeight { get; set; }
    }
}
