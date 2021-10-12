using System.IO;

namespace TextEditor
{
    public static class TextEditorSettings
    {
        public static string TempDirectory => $"{Path.GetTempPath()}TextEditor/";
        public static string ImagesDirectory => $"{TempDirectory}Images/";

        public static void InitializeDirectories()
        {
            Directory.CreateDirectory( TempDirectory );
            Directory.CreateDirectory( ImagesDirectory );
        }
    }
}
