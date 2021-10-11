using System;
using System.Collections.Generic;
using System.Linq;
using TextEditor.Commands;
using TextEditor.DocumentItems;
using TextEditor.DocumentItems.Image;
using TextEditor.DocumentItems.Paragraph;
using TextEditor.History;

namespace TextEditor.Document
{
    public class Document : IDocument
    {
        private List<IDocumentItem> _documentItems = new();
        private string _title = "Document";
        private DocumentHistory _history = new();

        public int ItemsCount => _documentItems.Count;

        public string Title
        {
            get => _title;
            set => _history.AddAndExecuteCommand( new ChangeFileNameCommand( this, value ) );
        }

        public bool CanUndo => _history.CanUndo;

        public bool CanRedo => _history.CanRedo;

        public Document()
        {

        }

        public Document( DocumentHistory history )
        {
            _history = history;
        }

        public void DeleteItem( int index )
        {
            if ( index < 0 || index > _documentItems.Count - 1 )
                throw new ArgumentOutOfRangeException( nameof( index ) );

            _documentItems.RemoveAt( index );
        }

        public IDocumentItem GetItem( int index )
        {
            if ( index < 0 || index > _documentItems.Count - 1 )
                throw new ArgumentOutOfRangeException( nameof( index ) );

            return _documentItems[ index ];
        }

        public void InsertImage( int width, int height, string srcPath, int position )
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

            _documentItems.Insert( position, new DocumentItem( new Image( width, height, srcPath ) ) );
        }

        public void InsertImage( int width, int height, string srcPath )
        {
            InsertImage( width, height, srcPath, _documentItems.Count - 1 );
        }

        public void InsertParagraph( string text, int position )
        {
            if ( text is null )
                throw new ArgumentNullException( nameof( text ), "Paragraph text can't be null" );

            if ( position > _documentItems.Count - 1 )
                throw new ArgumentException();

            _documentItems.Insert( position, new DocumentItem( new Paragraph( text ) ) );
        }

        public void InsertParagraph( string text )
        {
            if ( text is null )
                throw new ArgumentNullException( nameof( text ), "Paragraph text can't be null" );

            InsertParagraph( text, _documentItems.Count - 1 );
        }

        public void Redo()
        {
            if ( CanRedo )
                _history.Redo();
        }

        public void Save( string path )
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            if ( CanUndo )
                _history.Undo();
        }
    }
}
