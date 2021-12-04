namespace lw7.Styles
{
    public class CompositeFillStyle : IFillStyle
    {
        private IStylesEnumerator<IFillStyle> _stylesEnumerator;

        public bool IsEnabled
        {
            get
            {
                bool isEnabled = true;
                void checkIsEnable( IFillStyle style )
                {
                    if ( isEnabled && style is not null )
                    {
                        isEnabled = style.IsEnabled;
                    }
                };

                _stylesEnumerator?.Enumerate( checkIsEnable );

                return isEnabled;
            }
        }

        public IRGBAColor Color
        {
            get
            {
                IRGBAColor color = null;
                void action( IFillStyle style )
                {
                    if ( color == null || style.Color == color )
                    {
                        color = style.Color;
                    }
                    else
                    {
                        color = null;
                    }
                }

                _stylesEnumerator?.Enumerate( action );
                return color;
            }

            set
            {
                void action( IFillStyle style )
                {
                    if ( style is not null )
                    {
                        style.Color = value;
                    }
                }

                _stylesEnumerator?.Enumerate( action );
            }
        }

        public CompositeFillStyle( IStylesEnumerator<IFillStyle> stylesContainer )
        {
            _stylesEnumerator = stylesContainer ?? throw new ArgumentNullException( nameof( stylesContainer ) );
        }

        public void Enable()
        {
            static void action( IFillStyle style )
            {
                style?.Enable();
            }

            _stylesEnumerator.Enumerate( action );
        }

        public void Disable()
        {
            static void action( IFillStyle style )
            {
                style?.Disable();
            }

            _stylesEnumerator.Enumerate( action );
        }

        public bool Equals( IFillStyle other )
        {
            if ( other is null )
            {
                return false;
            }

            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }

            if ( other is CompositeFillStyle compositeFilleStyle )
            {
                return IsEnabled == compositeFilleStyle.IsEnabled
                    && Color == compositeFilleStyle.Color;
            }

            return false;
        }
    }
}
