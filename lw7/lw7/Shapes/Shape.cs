using lw7.Styles;

namespace lw7.Shapes
{
    public abstract class Shape : IShape
    {
        private IFillStyle _fillStyle;
        private IBorderStyle _borderStyle;
        private ICompositeShape _parent;
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

        public ICompositeShape Composite => null;

        public ICompositeShape Parent
        {
            get => _parent;
            set => _parent = value;
        }

        public Shape()
        {
            _fillStyle = new FillStyle();
            _borderStyle = new BorderStyle();
        }

        /// <summary>
        /// Simply sets private field _frame to frame argument
        /// </summary>
        /// <param name="frame"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void SetFrame( Frame frame )
        {
            _frame = frame ?? throw new ArgumentNullException( nameof( frame ) );
        }

        public virtual void Draw( ICanvas canvas )
        {
            if ( BorderStyle is not null )
            {
                canvas.SetBorderHeight( BorderStyle.BorderHeight );
                canvas.SetPenColor( BorderStyle.Color.R, BorderStyle.Color.G, BorderStyle.Color.B, BorderStyle.Color.A );
            }

            if ( FillStyle is not null )
            {
                canvas.SetFillColor( FillStyle.Color.R, FillStyle.Color.G, FillStyle.Color.B, FillStyle.Color.A );
            }
        }
    }
}
