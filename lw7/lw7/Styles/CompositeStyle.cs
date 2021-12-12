namespace lw7.Styles
{
    public abstract class CompositeStyle<T> : IStyle
        where T : IStyle
    {
        protected IStylesEnumerator<T> _stylesEnumerator;

        public bool IsEnabled
        {
            get
            {
                bool isEnabled = true;
                void action( T style )
                {
                    if ( isEnabled && style is not null )
                    {
                        isEnabled = style.IsEnabled;
                    }
                };

                _stylesEnumerator?.Enumerate( action );

                return isEnabled;
            }
        }

        public RGBAColor Color
        {
            get
            {
                RGBAColor curr = new();
                RGBAColor prev = new();
                void action( T style )
                {
                    prev = curr;
                    curr = style.Color;
                }

                _stylesEnumerator?.Enumerate( action );

                return curr.Equals( prev ) ? curr : new();
            }

            set
            {
                void action( T style )
                {
                    style.Color = value;
                }

                _stylesEnumerator?.Enumerate( action );
            }
        }

        public CompositeStyle( IStylesEnumerator<T> stylesContainer )
        {
            _stylesEnumerator = stylesContainer ?? throw new ArgumentNullException( nameof( stylesContainer ) );
        }

        public void Enable()
        {
            static void action( T style )
            {
                style?.Enable();
            }

            _stylesEnumerator.Enumerate( action );
        }

        public void Disable()
        {
            static void action( T style )
            {
                style?.Disable();
            }

            _stylesEnumerator.Enumerate( action );
        }

        public override bool Equals( object other )
        {
            if ( other is null )
            {
                return false;
            }

            if ( ReferenceEquals( this, other ) )
            {
                return true;
            }

            if ( other is CompositeStyle<T> compositeFilleStyle )
            {
                return IsEnabled == compositeFilleStyle.IsEnabled
                    && Color.Equals( compositeFilleStyle.Color );
            }

            return false;
        }
    }
}
