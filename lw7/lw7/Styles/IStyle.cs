namespace lw7
{
    public interface IStyle
    {
        public bool IsEnabled { get; }
        public RGBAColor Color { get; set; }
        public void Enable();
        public void Disable();
    }
}
