using lw7.Styles;

namespace lw7.Shapes
{
    public class CompositeShape : IGroup, IStylesEnumerator<IFillStyle>, IStylesEnumerator<IBorderStyle>
    {
        /// <summary>
        /// Stores link on parent object, null if shape isn't in group
        /// </summary>
        private IGroup _parent;
        /// <summary>
        /// List of shapes in group
        /// </summary>
        private List<IShape> _shapes = new();

        private CompositeFillStyle _fillStyle;
        private CompositeBorderStyle _borderStyle;

        public int ShapesCount => ( _shapes ??= new() ).Count;

        public Frame Frame => CountFrame();

        public IFillStyle FillStyle
        {
            get => _fillStyle;
        }

        public IBorderStyle BorderStyle
        {
            get => _borderStyle;
        }

        public IGroup Group => this;

        public IGroup Parent
        {
            get => _parent;
            set => _parent = value;
        }

        public CompositeShape()
        {
            _fillStyle = new( this );
            _borderStyle = new( this );
        }

        public void AddShape( IShape shape )
        {
            if ( shape.Parent is not null )
            {
                throw new InvalidOperationException( "Shape already in group" );
            }

            if ( _shapes.Contains( shape ) == true )
            {
                throw new InvalidOperationException();
            }

            if ( shape.HasParent( this ) )
            {
                throw new InvalidOperationException( "Can''t add shape beacause it will cause cycle" );
            }

            try
            {
                _shapes.Add( shape );
                shape.Parent = this;
            }
            catch ( Exception ex )
            {
                //do smth
                throw;
            }
        }

        public void Draw( ICanvas canvas )
        {
            foreach ( var shape in _shapes )
            {
                shape.Draw( canvas );
            }
        }

        public IShape GetShapeAt( int index )
        {
            if ( index > _shapes.Count - 1 )
            {
                throw new IndexOutOfRangeException();
            }

            return _shapes[ index ];
        }

        public void RemoveShape( int index )
        {
            if ( index > _shapes.Count - 1 )
            {
                throw new IndexOutOfRangeException();
            }

            _shapes[ index ].Parent = null;
            _shapes.RemoveAt( index );
        }

        void IStylesEnumerator<IFillStyle>.Enumerate( Action<IFillStyle> action )
        {
            foreach ( var shape in _shapes )
            {
                action( shape.FillStyle );
            }
        }

        void IStylesEnumerator<IBorderStyle>.Enumerate( Action<IBorderStyle> action )
        {
            foreach ( var shape in _shapes )
            {
                action( shape.BorderStyle );
            }
        }

        public void SetFrame( Frame frame )
        {
            throw new NotImplementedException();
        }

        private Frame CountFrame()
        {
            if ( _shapes is null || ( _shapes.Count == 0 ) )
            {
                return null;
            }

            //count frame;

            return null;
        }
    }
}
