using System.Linq;

namespace TextEditor
{
    public static class PathUtils
    {
        public static string NormalizePath( string path )
        {
            if ( path.Last() == '/' )
                return path;

            return $"{path}/";
        }

        public static string GetImageSubDirWithName( string imagePath )
        {
            return imagePath.Replace( TextEditorSettings.RootDirectory, string.Empty );
        }

        public static string GetSubDir( string src, string sub )
        {
            if ( src is null )
            {
                throw new System.ArgumentNullException( nameof( src ) );
            }

            if ( sub is null )
            {
                throw new System.ArgumentNullException( nameof( sub ) );
            }

            return $"{sub.Except( src )}";
        }
    }
}
