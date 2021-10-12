using System;
using System.IO;
using TextEditor.DocumentItems.Image;

namespace TextEditor
{
    class Program
    {
        public static string TempDirectory => $"{Path.GetTempPath()}TextEditor/";
        public static string ImagesDirectory => $"{TempDirectory}Images/";

        public static void Main( string[] args )
        {
            TextEditorSettings.InitializeDirectories();

            Image image = new( 384, 216, @"C:\Users\daniil.gerasimov\MyDocs\Учеба\3_stage\ood less than 3\ood\lw5\TextEditor\TextEditor\Assets\mountain.jpg" );
            image = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
