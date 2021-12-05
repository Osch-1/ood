namespace lw7.Styles
{
    public class CompositeBorderStyle : CompositeStyle<IBorderStyle>, IBorderStyle
    {
        public double BorderHeight
        {
            get
            {
                double height = -1;
                double firstHeight = -1;
                void action( IBorderStyle style )
                {
                    if ( height == -1 )
                    {
                        firstHeight = style.BorderHeight;
                    }

                    height = style.BorderHeight;
                }

                _stylesEnumerator?.Enumerate( action );

                return height == firstHeight ? height : -1;
            }

            set
            {
                if ( value < 0 )
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
            : base( stylesContainer )
        {
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

            var baseEquals = base.Equals( other );
            if ( !baseEquals )
            {
                return false;
            }

            if ( other is CompositeBorderStyle compositeFilleStyle )
            {
                return baseEquals && BorderHeight == compositeFilleStyle.BorderHeight;

            }

            return baseEquals;
        }
    }
}
