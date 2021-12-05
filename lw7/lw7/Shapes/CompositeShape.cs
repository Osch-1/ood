using lw7.Styles;

namespace lw7.Shapes
{
    public class CompositeShape : ICompositeShape, IStylesEnumerator<IFillStyle>, IStylesEnumerator<IBorderStyle>
    {
        /// <summary>
        /// Stores link on parent object, null if shape isn't in group
        /// </summary>
        private ICompositeShape _parent;
        /// <summary>
        /// List of shapes in group
        /// </summary>
        private List<IShape> _shapes = new();
        private Frame _frame;

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

        public ICompositeShape Composite => this;

        public ICompositeShape Parent
        {
            get => _parent;
            set => _parent = value;
        }

        public CompositeShape( IShape shape )
        {
            if ( shape is null )
            {
                throw new ArgumentNullException( nameof( shape ) );
            }

            _fillStyle = new( this );
            _borderStyle = new( this );
            _shapes.Add( shape );

            SetFrame( CountFrame() );
        }

        public void Draw( ICanvas canvas )
        {
            foreach ( var shape in _shapes )
            {
                shape.Draw( canvas );
            }
        }

        public void SetFrame( Frame frame )
        {
            TransformSettings transformSettings = new();
            if ( frame.LeftTop != _frame.LeftTop )
            {
                // move group
                double horizontalOffset = frame.LeftTopX - frame.LeftTopY;
                double verticalOffset = frame.LeftTopY - frame.LeftTopY;

                transformSettings.HorizontalOffset = horizontalOffset;
                transformSettings.VerticalOffset = verticalOffset;
            }

            if ( frame.Width != _frame.Width )
            {
                // horizontal scale
                double scailingRatio = frame.Width / _frame.Width;
                transformSettings.HorizontalScailing = scailingRatio;
            }

            if ( frame.Height != _frame.Height )
            {
                // vertical scale
                double scailingRatio = frame.Height / _frame.Height;
                transformSettings.VerticalScailing = scailingRatio;
            }

            foreach ( var shape in _shapes )
            {
                shape.SetFrame( CountNewFrame( shape.Frame, transformSettings ) );
            }

            _frame = frame;
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

        private Frame CountFrame()
        {
            if ( _shapes is null || ( _shapes.Count == 0 ) )
            {
                return null;
            }

            List<double> xes = new();
            List<double> ys = new();

            foreach ( var shape in _shapes )
            {
                xes.Add( shape.Frame.LeftTopX );
                ys.Add( shape.Frame.LeftTopY );
            }

            double maxX = xes.Max();
            double minX = xes.Min();
            double maxY = ys.Max();
            double minY = ys.Min();

            double frameWidth = maxX - minX;
            double frameHeight = maxY - minY;

            return new Frame( minX, maxY, frameWidth, frameHeight );
        }

        private static Frame CountNewFrame( Frame currentFrame, TransformSettings transformSettings )
        {
            double leftTopX = currentFrame.LeftTopX + transformSettings.HorizontalOffset;
            double leftTopY = currentFrame.LeftTopY + transformSettings.VerticalOffset;

            double width = currentFrame.Width * transformSettings.HorizontalScailing;
            double height = currentFrame.Height * transformSettings.VerticalScailing;

            return new Frame( leftTopX, leftTopY, width, height );
        }

        private class TransformSettings
        {
            /// <summary>
            /// x' - x, defines metric on which group has been moved horizontally
            /// </summary>
            public double HorizontalOffset { get; set; }
            /// <summary>
            /// y' - y, defines metric on which group has been moved vertically
            /// </summary>
            public double VerticalOffset { get; set; }
            /// <summary>
            /// w' / w, defines horizontal scailing
            /// </summary>
            public double HorizontalScailing { get; set; }
            /// <summary>
            /// h' / h, defines vertical scailing
            /// </summary>
            public double VerticalScailing { get; set; }
        }
    }
}
