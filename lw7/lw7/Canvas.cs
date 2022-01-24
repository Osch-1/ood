using System.Text;

namespace lw7
{
    public interface ICanvas
    {
        /// <summary>
        /// Draws line defined by starting and ending point
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void DrawLine( Point from, Point to );
        /// <summary>
        /// Draws ellipse defined by left top point, width and height
        /// </summary>
        /// <param name="leftTop"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawEllipse( Point leftTop, double width, double height );
        /// <summary>
        /// Fills ellipse defined by left top point, width and height
        /// </summary>
        /// <param name="leftTop"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void FillEllipse( Point leftTop, double width, double height );
        /// <summary>
        /// Fills rectangle by provided points
        /// </summary>
        /// <param name="points"></param>
        public void FillRectangle( IEnumerable<Point> points );
        /// <summary>
        /// Sets fill color
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void SetFillColor( int r, int g, int b, double a = 0 );
        /// <summary>
        /// Sets pen color
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public void SetPenColor( int r, int g, int b, double a = 0 );
        /// <summary>
        /// Sets border height
        /// </summary>
        /// <param name="height"></param>
        public void SetBorderHeight( double height );
    }

    public class Canvas : ICanvas
    {
        public void DrawEllipse( Point leftTop, double width, double height )
        {
            Console.WriteLine( $"DrawEllipse({leftTop}, {width}, {height})" );
        }

        public void DrawLine( Point from, Point to )
        {
            Console.WriteLine( $"DrawLine {from} -> {to}" );
        }

        public void FillEllipse( Point leftTop, double width, double height )
        {
            Console.WriteLine( $"FillEllipse({leftTop}, {width}, {height})" );
        }

        public void FillRectangle( IEnumerable<Point> points )
        {
            StringBuilder sb = new( 50 );
            foreach ( var point in points )
            {
                sb.Append( $"{point} " );
            }

            Console.WriteLine( $"FillRectangle({sb})" );
        }

        public void SetBorderHeight( double height )
        {
            Console.WriteLine( $"SetBorderHeight({height})" );
        }

        public void SetFillColor( int r, int g, int b, double a = 0 )
        {
            Console.WriteLine( $"SetFillColor({r}, {g}, {b}, {a})" );
        }

        public void SetPenColor( int r, int g, int b, double a = 0 )
        {
            Console.WriteLine( $"SetPenColor({r}, {g}, {b}, {a})" );
        }
    }
}
