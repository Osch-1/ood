using System;
using System.IO;

namespace TextEditor
{
    public static class TextEditorSettings
    {
        public static string IndexTemplateName => "index.html";
        public static string StyleTemplateName => "style.css";

        public static string ResultIndexName => "index.html";
        public static string ResultStyleName => "style.css";

        public static string RootDirectory => $"{Path.GetTempPath()}TextEditor/";
        public static string ImagesSubDirectory => "images/";
        public static string ImagesDirectory => $"{RootDirectory}{ImagesSubDirectory}";
        public static string IndexTemplatePath => $"{Directory.GetCurrentDirectory()}/Templates/{IndexTemplateName}";
        public static string StyleTemplatePath => $"{Directory.GetCurrentDirectory()}/Templates/{StyleTemplateName}";

        public static void InitializeWorkingDirectories()
        {
            Directory.CreateDirectory( RootDirectory );
            Directory.CreateDirectory( ImagesDirectory );
        }
    }
}
