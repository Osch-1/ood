namespace lw7.Styles
{
    public class CompositeBorderStyle : IBorderStyle
    {
        private IStylesContainer<IBorderStyle> _stylesContainer;

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
                IReadOnlyList<IBorderStyle> styles = _stylesContainer?.Get();
                if ( styles is null || !styles.Any() )
                    return null;

                var firstStyle = styles[ 0 ];
                foreach ( IBorderStyle style in styles )
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
                IReadOnlyList<IBorderStyle> styles = _stylesContainer?.Get();
                if ( styles is null || !styles.Any() )
                {
                    throw new InvalidOperationException( "Can't set color due to current state of container (style empty or null)" );
                }

                foreach ( IBorderStyle style in styles )
                {
                    if ( style is not null )
                    {
                        style.Color = value;
                    }
                }
            }
        }

        public double BorderHeight
        {
            get
            {
                IReadOnlyList<IBorderStyle> styles = _stylesContainer?.Get();
                if ( styles is null || !styles.Any() )
                    return 0;

                var firstStyle = styles.First();
                foreach ( IBorderStyle style in styles )
                {
                    if ( !style.Equals( firstStyle ) )
                        return 0;
                }

                return firstStyle.BorderHeight;
            }

            set
            {
                IReadOnlyList<IBorderStyle> styles = _stylesContainer?.Get();
                if ( styles is null || !styles.Any() )
                {
                    throw new InvalidOperationException( "Can't set border height due to current state of container (style empty or null)" );
                }

                foreach ( IBorderStyle style in styles )
                {
                    if ( style is not null )
                    {
                        style.BorderHeight = value;
                    }
                }
            }
        }

        public CompositeBorderStyle( IStylesContainer<IBorderStyle> stylesContainer )
        {
            _stylesContainer = stylesContainer ?? throw new ArgumentNullException( nameof( stylesContainer ) );
        }

        public void Enable()
        {
            IEnumerable<IBorderStyle> styles = _stylesContainer?.Get();
            foreach ( IBorderStyle style in styles )
            {
                style.Enable();
            }
        }

        public void Disable()
        {
            IEnumerable<IBorderStyle> styles = _stylesContainer?.Get();
            foreach ( IBorderStyle style in styles )
            {
                style.Disable();
            }
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
