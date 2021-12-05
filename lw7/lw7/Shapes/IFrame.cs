namespace lw7
{
    public class Frame
    {
        public double LeftTopX { get; set; }
        public double LeftTopY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Point LeftTop => new( LeftTopX, LeftTopY );

        public Frame( double leftTopX, double leftTopY, double width, double height )
        {
            if ( width <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( width ) );
            }

            if ( height <= 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( height ) );
            }

            if ( width == 0 && height == 0 )
            {
                throw new ArgumentException( "Parameters width and height can't be 0 in the same time" );
            }

            LeftTopX = leftTopX;
            LeftTopY = leftTopY;
            Width = width;
            Height = height;
        }
    }
}