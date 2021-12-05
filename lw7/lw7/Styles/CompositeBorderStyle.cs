namespace lw7.Styles
{
    public class CompositeBorderStyle : IBorderStyle
    {
        private IStylesEnumerator<IBorderStyle> _stylesEnumerator;

        public bool IsEnabled
        {
            get
            {
                bool isEnabled = true;
                void checkIsEnable( IBorderStyle style )
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

        public RGBAColor Color
        {
            get
            {
                RGBAColor color = null;
                void action( IBorderStyle style )
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
                void action( IBorderStyle style )
                {
                    if ( style is not null )
                    {
                        style.Color = value;
                    }
                }

                _stylesEnumerator?.Enumerate( action );
            }
        }

        public double BorderHeight
        {
            get
            {
                double borderHeight = -1;
                void action( IBorderStyle style )
                {
                    if ( borderHeight == -1 || style.BorderHeight == borderHeight )
                    {
                        borderHeight = style.BorderHeight;
                    }
                    else
                    {
                        borderHeight = -1;
                    }
                }

                _stylesEnumerator?.Enumerate( action );
                return borderHeight;
            }

            set
            {
                if ( value <= 0 )
                {
                    throw new ArgumentOutOfRangeException( nameof( value ) );
                }

                void action( IBorderStyle style )
                {
                    if ( style is not null )
                    {
                        style.BorderHeight = value;
                    }
                }

                _stylesEnumerator?.Enumerate( action );
            }
        }

        public CompositeBorderStyle( IStylesEnumerator<IBorderStyle> stylesContainer )
        {
            _stylesEnumerator = stylesContainer ?? throw new ArgumentNullException( nameof( stylesContainer ) );
        }

        public void Enable()
        {
            static void action( IBorderStyle style )
            {
                style?.Enable();
            }

            _stylesEnumerator.Enumerate( action );
        }

        public void Disable()
        {
            static void action( IBorderStyle style )
            {
                style?.Disable();
            }

            _stylesEnumerator.Enumerate( action );
        }

        public bool Equals( IBorderStyle other )
        {
            if ( other is null )
            {
                return false;
            }

            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }

            if ( other is CompositeBorderStyle compositeFilleStyle )
            {
                return IsEnabled == compositeFilleStyle.IsEnabled
                    && Color == compositeFilleStyle.Color
                    && BorderHeight == compositeFilleStyle.BorderHeight;
            }

            return false;
        }
    }
}
