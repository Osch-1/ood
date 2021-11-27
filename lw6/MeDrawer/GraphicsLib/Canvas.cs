namespace GraphicsLib
{
    /// <summary>
    /// Api для рисования графических примитивов
    /// </summary>
    public interface ICanvas
    {
        public void SetColor( int rgbColor );
        public void MoveTo( int x, int y );
        public void LineTo( int x, int y );
    }

    public class Canvas : ICanvas
    {
        /// <summary>
        /// Установка цвета в формате 0xRRGGBB
        /// </summary>
        /// <param name="rgbColor"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetColor( int rgbColor )
        {
            Console.WriteLine( $"SetColor ({ToColor( rgbColor )})" );
        }

        /// <summary>
        /// Ставит перо в точку x, y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveTo( int x, int y )
        {
            Console.WriteLine( $"MoveTo ({x} {y})" );
        }

        /// <summary>
        /// Рисует линию с текущей позиции, передвигая перо в точку x,y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void LineTo( int x, int y )
        {
            Console.WriteLine( $"LineTo ({x} {y})" );
            MoveTo( x, y );
        }

        /// <summary>
        /// Converts int representation of RGB color to string with #RRGGBB format
        /// </summary>
        /// <param name="rgbColor"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static string ToColor( int rgbColor )
        {
            if ( rgbColor < 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( rgbColor ) );
            }

            return $"#{( rgbColor >> 16 ) & 0xff}{( rgbColor >> 8 ) & 0xff}{( rgbColor >> 0 ) & 0xff}";
        }
    }
}