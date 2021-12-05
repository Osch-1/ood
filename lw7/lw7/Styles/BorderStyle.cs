namespace lw7.Styles
{
    public class BorderStyle : IBorderStyle
    {
        private RGBAColor _color = new ( 0, 0, 0, 1 );
        private bool _isEnabled = true;
        private double _borderHeight = 1;

        public double BorderHeight
        {
            get => _borderHeight;
            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentOutOfRangeException( nameof( value ) );
                }

                _borderHeight = value;
            }
        }

        public bool IsEnabled => _isEnabled;

        public RGBAColor Color
        {
            get => _color;
            set
            {
                if ( value is not null )
                {
                    _color = value;
                }
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
