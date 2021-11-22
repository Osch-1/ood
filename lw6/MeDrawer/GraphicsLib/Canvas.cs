namespace GraphicsLib
{
    /// <summary>
    /// Api для рисования графических примитивов
    /// </summary>
    public interface ICanvas
    {
        public void MoveTo( int x, int y );
        public void LineTo( int x, int y );
    }

    public class Canvas : ICanvas
    {
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
    }
}