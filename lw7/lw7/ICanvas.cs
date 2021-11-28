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
}
