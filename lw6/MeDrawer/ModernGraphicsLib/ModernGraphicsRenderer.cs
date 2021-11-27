using System.Text;

namespace ModernGraphicsLib
{
    public class ModernGraphicsRenderer : IDisposable
    {
        private const string _openingTag = "<draw>";
        private const string _closingTag = "</draw>";
        private const string _drawLineTagTemplate = "<line fromX=\"{0}\" fromY=\"{1}\" toX=\"{2}\" toY=\"{3}\">\n  <color r=\"{4}\" g=\"{5}\" b=\"{6}\" a=\"{7}\" />\n</line>";

        private static readonly byte[] _openingTagBytes = Encoding.UTF8.GetBytes( _openingTag );
        private static readonly byte[] _closingTagBytes = Encoding.UTF8.GetBytes( _closingTag );

        private Stream _stream;
        private bool _drawing = false;

        public ModernGraphicsRenderer( Stream stream )
        {
            if ( stream is null )
            {
                throw new ArgumentNullException( nameof( stream ) );
            }

            if ( stream.CanWrite is false )
            {
                throw new ArgumentException( "Stream must be writable", nameof( stream ) );
            }

            _stream = stream;
        }

        public void BeginDraw()
        {
            if ( _drawing )
            {
                throw new InvalidOperationException();
            }

            _stream.Write( _openingTagBytes );
            _drawing = true;
        }

        public void DrawLine( Point start, Point end, RGBAColor color )
        {
            if ( !_drawing )
            {
                throw new InvalidOperationException();
            }

            var drawLineTagWithValues = string.Format( _drawLineTagTemplate, start.X, start.Y, end.X, end.Y, color.R, color.G, color.B, color.A );
            _stream.Write( Encoding.UTF8.GetBytes( drawLineTagWithValues ) );
        }

        public void EndDraw()
        {
            if ( !_drawing )
            {
                throw new InvalidOperationException();
            }

            _stream.Write( _closingTagBytes );
            _drawing = false;
        }

        public void Dispose()
        {
            if ( _drawing )
            {
                EndDraw();
            }

            GC.SuppressFinalize( this );
        }
    }
}