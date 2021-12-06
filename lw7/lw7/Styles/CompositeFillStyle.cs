namespace lw7.Styles
{
    public class CompositeFillStyle : CompositeStyle<IFillStyle>, IFillStyle
    {
        public CompositeFillStyle( IStylesEnumerator<IFillStyle> stylesContainer )
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

            return base.Equals( other );
        }
    }
}
