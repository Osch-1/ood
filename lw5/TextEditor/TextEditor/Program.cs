using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        public static void Main( string[] args )
        {
            TextEditorSettings.InitializeWorkingDirectories();
            DocumentController controller = new();

            string command = "";
            while ( command != "exit" )
            {
                Console.WriteLine( Resources.CommandsInfo );
                controller.Handle( ReadCommand() );
            }

            Directory.Delete( TextEditorSettings.RootDirectory.Remove( TextEditorSettings.RootDirectory.Length - 1 ), true );
        }

        public static string ReadCommand()
        {
            return Console.ReadLine();
        }
    }
}
