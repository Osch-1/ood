namespace lw7.Styles
{
    public class FillStyle : IFillStyle
    {
        private RGBAColor _color = new( 0, 0, 0, 1 );
        private bool _isEnabled = true;

        public bool IsEnabled => _isEnabled;

        public RGBAColor Color
        {
            get => _color;
            set
            {
                _color = value;
            }
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}
