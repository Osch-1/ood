namespace lw7.Shapes
{
    public abstract class Shape : IShape
    {
        private IFillStyle _fillStyle;
        private IBorderStyle _borderStyle;
        private IGroup _parent;
        private Frame _frame;

        public Frame Frame => _frame;

        public IFillStyle FillStyle
        {
            get => _fillStyle;
        }

        public IBorderStyle BorderStyle
        {
            get => _borderStyle;
        }

        public IGroup Group => _parent;

        public IGroup Parent
        {
            get => _parent;
            set => _parent = value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( _fillStyle, _borderStyle, Frame, FillStyle, BorderStyle, Group );
        }

        public virtual void SetFrame( Frame frame )
        {
            _frame = frame;
        }

        public virtual void Draw( ICanvas canvas )
        {
            if ( BorderStyle is not null )
            {
                canvas.SetBorderHeight( BorderStyle.BorderHeight );

                if ( BorderStyle.Color is not null )
                {
                    canvas.SetPenColor( BorderStyle.Color.R, BorderStyle.Color.G, BorderStyle.Color.B, BorderStyle.Color.A );
                }
            }

            if ( FillStyle is not null && FillStyle.Color is not null )
            {
                canvas.SetFillColor( FillStyle.Color.R, FillStyle.Color.G, FillStyle.Color.B, FillStyle.Color.A );
            }
        }
    }
}
