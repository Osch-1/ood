using System;
using System.Collections.Generic;
using System.Linq;
using TextEditor.History;
using TextEditor.Commands;

namespace TextEditor
{
    public class DocumentController
    {
        private IHistory _history;
        private readonly IDocument _document;

        public DocumentController()
        {
            _history = new DocumentHistory();
            _document = new Document.Document( ( DocumentHistory )_history );
        }

        public void Handle( string command )
        {
            var commandParams = command.Split( ' ' ).ToList();
            switch ( commandParams[ 0 ] )
            {
                case CommandsNames.InsertParagraph:
                    InsertParagraph( commandParams );
                    break;
                case CommandsNames.InsertImage:
                    InsertImage( commandParams );
                    break;
                case CommandsNames.SetTitle:
                    SetTitle( commandParams );
                    break;
                case CommandsNames.List:
                    _document.List();
                    break;
                case CommandsNames.ReplaceText:
                    ReplaceText( commandParams );
                    break;
                case CommandsNames.ResizeImage:
                    ResizeImage( commandParams );
                    break;
                case CommandsNames.DeleteItem:
                    DeleteItem( commandParams );
                    break;
                case CommandsNames.Help:
                    Help();
                    break;
                case CommandsNames.Undo:
                    Undo();
                    break;
                case CommandsNames.Redo:
                    Redo();
                    break;
                case CommandsNames.Save:
                    Save( commandParams );
                    break;
                default:
                    Console.WriteLine( "Incorrect command" );
                    break;
            }
        }

        private void InsertParagraph( List<string> cmdParams )
        {
            if ( cmdParams.Count < 3 )
            {
                Console.WriteLine( "Incorrect params count" );
                return;
            }

            if ( cmdParams[ 1 ].Equals( "end", StringComparison.OrdinalIgnoreCase ) )
            {
                _document.InsertParagraph( string.Join( " ", cmdParams.ToArray()[ 2.. ] ) );
            }
            else
            {
                try
                {
                    _document.InsertParagraph( string.Join( " ", cmdParams.ToArray()[ 2.. ] ), int.Parse( cmdParams[ 1 ] ) ); ;
                }
                catch ( Exception e )
                {
                    Console.WriteLine( e.Message );
                }

            }
        }

        private void InsertImage( List<string> cmdParams )
        {
            if ( cmdParams.Count < 5 )
            {
                Console.WriteLine( "Incorrect params count" );
                return;
            }

            if ( cmdParams[ 1 ].Equals( "end", StringComparison.OrdinalIgnoreCase ) )
            {
                try
                {
                    _document.InsertImage( int.Parse( cmdParams[ 2 ] ), int.Parse( cmdParams[ 3 ] ), cmdParams[ 4 ] );
                }
                catch ( Exception e )
                {
                    Console.WriteLine( e.Message );
                }
            }
            else
            {
                try
                {
                    _document.InsertImage( int.Parse( cmdParams[ 2 ] ), int.Parse( cmdParams[ 3 ] ), cmdParams[ 4 ], int.Parse( cmdParams[ 1 ] ) );
                }
                catch ( Exception e )
                {
                    Console.WriteLine( e.Message );
                }
            }
        }

        private void SetTitle( List<string> cmdParams )
        {
            if ( cmdParams.Count < 2 )
            {
                Console.WriteLine( "Incorrect params count" );
                return;
            }

            _document.Title = cmdParams[ 1 ];
        }

        private void ReplaceText( List<string> cmdParams )
        {
            if ( cmdParams.Count < 3 )
            {
                Console.WriteLine( "Incorrect params count" );
                return;
            }

            int pos = int.Parse( cmdParams[ 1 ] );
            if ( pos > _document.ItemsCount - 1 )
            {
                Console.WriteLine( "Incorrect text index" );
                return;
            }

            var item = _document.GetItem( pos );
            if ( item.Paragraph is null )
            {
                Console.WriteLine( $"Item by index {pos} is not a paragraph" );
                return;
            }

            _history.AddAndExecuteCommand( new ReplaceTextCommand( item.Paragraph, cmdParams[ 2 ] ) );
        }

        private void ResizeImage( List<string> cmdParams )
        {
            if ( cmdParams.Count < 4 )
            {
                Console.WriteLine( "Incorrect params count" );
                return;
            }

            int pos = int.Parse( cmdParams[ 1 ] );
            if ( pos > _document.ItemsCount - 1 )
            {
                Console.WriteLine( "Incorrect text index" );
                return;
            }

            var item = _document.GetItem( pos );
            if ( item.Image is null )
            {
                Console.WriteLine( $"Item by index {pos} is not an image" );
                return;
            }

            _history.AddAndExecuteCommand( new ResizeImage( item.Image, int.Parse( cmdParams[ 2 ] ), int.Parse( cmdParams[ 3 ] ) ) );
        }

        private void DeleteItem( List<string> cmdParams )
        {
            if ( cmdParams.Count < 2 )
            {
                Console.WriteLine( "Incorrect params count" );
                return;
            }

            try
            {
                _document.DeleteItem( int.Parse( cmdParams[ 1 ] ) );
            }
            catch ( Exception e )
            {
                Console.WriteLine( "Couldnt delete item: ", e.Message );
            }
        }

        private void Help()
        {
            Console.WriteLine( Resources.CommandsInfo );
        }

        private void Undo()
        {
            if ( _document.CanUndo )
                _document.Undo();
        }

        private void Redo()
        {
            if ( _document.CanRedo )
                _document.Redo();
        }

        private void Save( List<string> cmdParams )
        {
            if ( cmdParams.Count < 2 )
            {
                Console.WriteLine( "Incorrect params count" );
                return;
            }

            try
            {
                _document.Save( cmdParams[ 1 ] );
            }
            catch ( Exception e )
            {
                Console.WriteLine( "Couldnt save file: ", e.Message );
            }
        }
    }
    public static class CommandsNames
    {
        public const string InsertParagraph = "InsertParagraph";
        public const string InsertImage = "InsertImage";
        public const string SetTitle = "SetTitle";
        public const string List = "List";
        public const string ReplaceText = "ReplaceText";
        public const string ResizeImage = "ResizeImage";
        public const string DeleteItem = "DeleteItem";
        public const string Help = "Help";
        public const string Undo = "Undo";
        public const string Redo = "Redo";
        public const string Save = "Save";
    }
}
