using System;
using System.IO;
using System.Linq;

namespace TextEditor.DocumentItems.Image
{
    public class Image : IImage
    {
        private string _path;
        private int _width;
        private int _height;
        private string _name;

        public Image( int width, int height, string srcPath )
        {
            if ( srcPath is null )
                throw new ArgumentNullException( nameof( srcPath ), "Path can't be empty" );

            if ( !srcPath.Any() )
                throw new ArgumentException( "Path can't be empty", nameof( srcPath ) );

            if ( width < 0 )
                throw new ArgumentException( "Width must be greater than 0", nameof( width ) );

            if ( height < 0 )
                throw new ArgumentException( "Height must be greater than 0", nameof( height ) );

            _name = Guid.NewGuid().ToString();
            _path = GenerateStoringPath( _name );

            if ( !File.Exists( srcPath ) )
                throw new ArgumentException( $"File referenced by srcPath param doesnt exists, check path and file, provided path: {srcPath}" );

            if ( File.GetAttributes(srcPath).)
            File.Move( srcPath, _path );

            _width = width;
            _height = height;
        }

        public string Path => _path;

        public int Width => _width;

        public int Height => _height;

        public void Resize( int width, int height )
        {
            throw new NotImplementedException();
        }

        private string GenerateStoringPath( string fileName )
        {
            return $"{System.IO.Path.GetTempPath()}{fileName}";
        }
    }
}
