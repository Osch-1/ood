namespace lw7.Styles
{
    public class CompositeFillStyle : IFillStyle
    {
        private IStylesContainer<IFillStyle> _stylesContainer;

        public bool IsEnabled
        {
            get
            {
                var styles = _stylesContainer?.Get();
                if ( styles is null )
                {
                    return false;
                }

                return styles.All( s => s is not null && s.IsEnabled );
            }
        }

        public IRGBAColor Color
        {
            get
            {
                IReadOnlyList<IFillStyle> styles = _stylesContainer?.Get();
                if ( styles is null || !styles.Any() )
                {
                    return null;
                }

                var firstStyle = styles.First();
                foreach ( IFillStyle style in styles )
                {
                    if ( !style.Equals( firstStyle ) )
                    {
                        return null;
                    }
                }

                return firstStyle.Color;
            }

            set
            {
                IReadOnlyList<IFillStyle> styles = _stylesContainer?.Get();
                if ( styles is null || !styles.Any() )
                {
                    throw new InvalidOperationException( "Can't set style due to current state of container (style empty or null)" );
                }

                foreach ( IFillStyle style in styles )
                {
                    if ( style is not null )
                    {
                        style.Color = value;
                    }
                }
            }
        }

        public CompositeFillStyle( IStylesContainer<IFillStyle> stylesContainer )
        {
            _stylesContainer = stylesContainer ?? throw new ArgumentNullException( nameof( stylesContainer ) );
        }

        public void Enable()
        {
            IEnumerable<IFillStyle> styles = _stylesContainer?.Get();
            foreach ( IFillStyle style in styles )
            {
                style.Enable();
            }
        }

        public void Disable()
        {
            IEnumerable<IFillStyle> styles = _stylesContainer?.Get();
            foreach ( IFillStyle style in styles )
            {
                style.Disable();
            }
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
