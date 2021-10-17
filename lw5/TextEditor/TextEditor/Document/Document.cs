using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextEditor.Commands;
using TextEditor.DocumentItems;
using TextEditor.DocumentItems.Image;
using TextEditor.DocumentItems.Paragraph;
using TextEditor.History;
using TextEditor.Savers;

namespace TextEditor.Document
{
    public class Document : IDocument
    {
        private List<IDocumentItem> _documentItems = new();
        private string _title = "Document";
        private IHistory _history;
        private string _path;
        private IDocumentSaver _saver = new AsHtmlSaver();

        public int ItemsCount => _documentItems.Count;

        public string Title
        {
            get => _title;
            set => _history.AddAndExecuteCommand( new ChangeDocumentTitleCommand( this, value ) );
        }

        public bool CanUndo => _history.CanUndo;

        public bool CanRedo => _history.CanRedo;

        public Document( IHistory history )
        {
            _history = history;
        }

        public void DeleteItem( int index )
        {
            if ( index < 0 || index > _documentItems.Count - 1 )
                throw new ArgumentOutOfRangeException( nameof( index ) );

            _history.AddAndExecuteCommand( new DeleteItemCommand( _documentItems, index ) );
        }

        public IDocumentItem GetItem( int index )
        {
            if ( index < 0 || index > _documentItems.Count - 1 )
                throw new ArgumentOutOfRangeException( nameof( index ) );

            return _documentItems[ index ];
        }

        public void InsertImage( int width, int height, string srcPath, int? position = null )
        {
            if ( srcPath is null )
                throw new ArgumentNullException( nameof( srcPath ), "Path can't be null" );

            if ( !srcPath.Any() )
                throw new ArgumentException( "Path can't be empty", nameof( srcPath ) );

            if ( width < 0 )
                throw new ArgumentException( "Width must be greater than 0", nameof( width ) );

            if ( height < 0 )
                throw new ArgumentException( "Height must be greater than 0", nameof( height ) );

            if ( position < 0 || position > _documentItems.Count - 1 )
                throw new ArgumentOutOfRangeException( nameof( position ) );

            InsertItemCommand command;
            var documentItem = new DocumentItem( new Image( width, height, srcPath ) );
            if ( position.HasValue )
            {
                command = new InsertItemCommand( _documentItems, documentItem, position );
            }
            else
            {
                command = new InsertItemCommand( _documentItems, documentItem );
            }

            _history.AddAndExecuteCommand( command );
        }

        public void InsertParagraph( string text, int? position = null )
        {
            if ( text is null )
                throw new ArgumentNullException( nameof( text ), "Paragraph text can't be null" );

            if ( position.HasValue && position > _documentItems.Count - 1 )
                throw new ArgumentException();

            InsertItemCommand command;
            var documentItem = new DocumentItem( new Paragraph( text ) );
            if ( position.HasValue )
            {
                command = new InsertItemCommand( _documentItems, documentItem, position );
            }
            else
            {
                command = new InsertItemCommand( _documentItems, documentItem );
            }

            _history.AddAndExecuteCommand( command );
        }

        public void Redo()
        {
            if ( CanRedo )
                _history.Redo();
        }

        public void Undo()
        {
            if ( CanUndo )
                _history.Undo();
        }

        public void Save( string path )
        {
            if ( _path != null )
                Directory.Delete( _path );

            _path = path;
            SetupDirectory();
            _saver.Save( _title, _documentItems, _path );
        }

        private void SetupDirectory()
        {
            Directory.CreateDirectory( $"{_path}/TextEditor" );
        }

        public void List()
        {
            Console.WriteLine( $"Title: {_title}" );
            for ( int i = 0; i < _documentItems.Count; i++ )
            {
                Console.WriteLine( $"{i}. {_documentItems[ i ]}" );
            }
        }
    }
}
