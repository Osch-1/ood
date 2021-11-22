using System;
using System.Collections.Generic;
using System.Linq;

namespace TextEditor.Extensions
{
    public enum FileType
    {
        Unknown,
        Jpeg,
        Bmp,
        Gif,
        Png,
        Pdf
    }

    public static class FileExtensions
    {
        private static readonly Dictionary<FileType, byte[]> _knownFileHeaders = new Dictionary<FileType, byte[]>()
        {
            { FileType.Jpeg, new byte[]{ 0xFF, 0xD8 }}, // JPEG
		    { FileType.Bmp, new byte[]{ 0x42, 0x4D }}, // BMP
		    { FileType.Gif, new byte[]{ 0x47, 0x49, 0x46 }}, // GIF
		    { FileType.Png, new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }}, // PNG		    
	    };

        public static FileType GetKnownFileType( this ReadOnlySpan<byte> data )
        {
            foreach ( var fileHeader in _knownFileHeaders )
            {
                if ( data.Length >= fileHeader.Value.Length )
                {
                    var slice = data.Slice( 0, fileHeader.Value.Length );
                    if ( slice.SequenceEqual( fileHeader.Value ) )
                    {
                        return fileHeader.Key;
                    }
                }
            }

            return FileType.Unknown;
        }

        public static bool IsImage( this ReadOnlySpan<byte> data )
        {
            return data.GetKnownFileType() != FileType.Unknown;
        }        
    }
}
