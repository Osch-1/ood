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

            while ( true )
            {
                Console.WriteLine( Resources.CommandsInfo );

                var command = ReadCommand();
                if ( command.Equals( "exit", StringComparison.OrdinalIgnoreCase ) )
                    break;

                controller.Handle( command );
            }

            Directory.Delete( TextEditorSettings.RootDirectory.Remove( TextEditorSettings.RootDirectory.Length - 1 ), true );
        }

        public static string ReadCommand()
        {
            return Console.ReadLine();
        }
    }
}
