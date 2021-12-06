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

        public Frame Frame => _frame;

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

        public CompositeShape( IReadOnlyCollection<IShape> shapes )
        {
            if ( shapes is null || !shapes.Any() )
            {
                throw new ArgumentNullException( nameof( shapes ) );
            }

            if ( shapes.Count < 2 )
            {
                throw new ArgumentException( "Composite shape can't be created from less than 2 shapes" );
            }

            foreach ( var shape in shapes )
            {
                AddShape( shape );
            }

            _frame = CountFrame();
            _fillStyle = new( this );
            _borderStyle = new( this );
        }

        public void Draw( ICanvas canvas )
        {
            foreach ( var shape in _shapes )
            {
                shape.Draw( canvas );
            }
        }

        //Don't call on shapes manipulation, will cause shapes transformation
        public void SetFrame( Frame frame )
        {
            TransformSettings transformSettings = new();
            if ( !frame.LeftTop.Equals( _frame.LeftTop ) )
            {
                double horizontalOffset = frame.LeftTopX - _frame.LeftTopX;
                double verticalOffset = frame.LeftTopY - _frame.LeftTopY;

                transformSettings.HorizontalOffset = horizontalOffset;
                transformSettings.VerticalOffset = verticalOffset;
            }

            if ( frame.Width != _frame.Width )
            {
                double scailingRatio = frame.Width / _frame.Width;
                transformSettings.HorizontalScailing = scailingRatio;
            }

            if ( frame.Height != _frame.Height )
            {
                double scailingRatio = frame.Height / _frame.Height;
                transformSettings.VerticalScailing = scailingRatio;
            }

            foreach ( var shape in _shapes )
            {
                shape.SetFrame( CountNewShapeFrame( shape.Frame, transformSettings ) );
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

            _frame = CountFrame();
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

            _frame = CountFrame();
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
                throw new InvalidOperationException( "CompositeShape contains 0 shapes or it's storage is null, can't count frame" );
            }

            List<double> minXes = new();
            List<double> maxXes = new();
            List<double> minYs = new();
            List<double> maxYs = new();

            foreach ( var shape in _shapes )
            {
                var frame = shape.Frame;
                minXes.Add( frame.LeftTopX );
                maxXes.Add( frame.LeftTopX + frame.Width );
                maxYs.Add( frame.LeftTopY );
                minYs.Add( frame.LeftTopY - frame.Height );

            }

            double maxX = maxXes.Max();
            double minX = minXes.Min();
            double maxY = maxYs.Max();
            double minY = minYs.Min();

            double frameWidth = maxX - minX;
            double frameHeight = maxY - minY;

            return new Frame( minX, maxY, frameWidth, frameHeight );
        }

        private static Frame CountNewShapeFrame( Frame currentFrame, TransformSettings transformSettings )
        {
            double leftTopX = currentFrame.LeftTopX + transformSettings.HorizontalOffset;
            double leftTopY = currentFrame.LeftTopY + transformSettings.VerticalOffset;

            double width = currentFrame.Width;
            if ( transformSettings.HorizontalScailing != 0 )
            {
                width = currentFrame.Width * transformSettings.HorizontalScailing;
            }

            double height = currentFrame.Height;
            if ( transformSettings.VerticalScailing != 0 )
            {
                height = currentFrame.Height * transformSettings.VerticalScailing;
            }

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
