using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using TextEditor.Extensions;

namespace TextEditor.DocumentItems.Image
{
    public class Image : IImage
    {
        private string _path;
        private int _width;
        private int _height;
        private string _name;
        private readonly System.Drawing.Image _image;

        //Might add ctor by file path only
        public Image( int width, int height, string srcPath )
        {
            if ( srcPath is null )
                throw new ArgumentNullException( nameof( srcPath ), "Path can't be empty" );

            if ( !srcPath.Any() )
                throw new ArgumentException( "Path can't be empty", nameof( srcPath ) );

            if ( width < 0 )
                throw new ArgumentException( "Width must be greater than 0", nameof( width ) );

            if ( width > 10000 )
                throw new ArgumentOutOfRangeException( "Width must be less than 10000 and greater than 0", nameof( width ) );

            if ( height < 0 )
                throw new ArgumentException( "Height must be greater than 0", nameof( height ) );

            if ( height > 10000 )
                throw new ArgumentOutOfRangeException( "Height must be less than 10000 and greater than 0", nameof( height ) );

            _name = GenerateName( srcPath );
            _path = GeneratePath( _name );

            if ( !File.Exists( srcPath ) || !File.ReadAllBytes( srcPath ).AsReadOnlySpan().IsImage() )
                throw new ArgumentException( $"File referenced by srcPath param doesnt exist, check path and file, provided path: {srcPath}" );

            //xd xd
            _image = System.Drawing.Image.FromFile( srcPath );
            var resizedImage = ResizeImage( _image, width, height );
            resizedImage.Save( _path );

            _width = width;
            _height = height;
        }

        public string Path => _path;

        public int Width => _width;

        public int Height => _height;

        public string Name => _name;

        public void Resize( int width, int height )
        {
            if ( width < 0 )
                throw new ArgumentException( "Width must be greater than 0", nameof( width ) );

            if ( height < 0 )
                throw new ArgumentException( "Height must be greater than 0", nameof( height ) );

            string nameBeforeChanges = _name;
            string pathBeforeChanges = _path;
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile( _path );

                var resizedImage = ResizeImage( image, width, height );
                _name = GenerateName( _path );
                _path = GeneratePath( _name );
                resizedImage.Save( _path );
            }
            catch ( Exception e )
            {
                _name = nameBeforeChanges;
                _path = pathBeforeChanges;

                throw new Exception( "Couldn't resize image", e.InnerException );
            }
        }

        public override string ToString()
        {
            return $"Image: {_width} {_height} images/{_name}";
        }

        private static string GenerateName( string srcPath )
        {
            FileType fileType = File.ReadAllBytes( srcPath ).AsReadOnlySpan().GetKnownFileType();
            if ( fileType == FileType.Unknown )
                throw new ArgumentException();

            string fileTypeNamestring = fileType.ToString();

            return $"{Guid.NewGuid()}.{fileTypeNamestring.ToLower()}";
        }

        private static string GeneratePath( string fileName ) => $"{TextEditorSettings.ImagesDirectory}{fileName}";

        // just use existing things ̿ ̿ ̿'̿'\̵͇̿̿\з=(•_•)=ε/̵͇̿̿/'̿'̿ ̿
        // actually it can be simplified to stream bypassing, but without quality saving and other things
        private Bitmap ResizeImage( System.Drawing.Image image, int width, int height )
        {
            var destRect = new Rectangle( 0, 0, width, height );
            var destImage = new Bitmap( width, height );

            destImage.SetResolution( image.HorizontalResolution, image.VerticalResolution );

            using ( var graphics = Graphics.FromImage( destImage ) )
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using ( var wrapMode = new ImageAttributes() )
                {
                    wrapMode.SetWrapMode( WrapMode.TileFlipXY );
                    graphics.DrawImage( image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode );
                }
            }

            _width = width;
            _height = height;

            return destImage;
        }
    }
}
