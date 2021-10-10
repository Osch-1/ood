using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TextEditor.DocumentItems;

namespace TextEditor.Document
{
    public class Document : IDocument
    {
        private List<IDocumentItem> _documentItems = new();
        private int _currentCommandIndex;

        private string _title = "Document";

        public int ItemsCount => _documentItems.Count;

        public string Title
        {
            get => _title;
            set => _title = value is null ? "" : value;
        }

        //и чо это значит?____))))))))))))))))))))))))))0
        public bool CanUndo => _documentItems.Any();

        //и чо это значит?____))))))))))))))))))))))))))0
        public bool CanRedo => throw new NotImplementedException();

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
                throw new ArgumentNullException( nameof( srcPath ), "Path can't be empty" );

            if ( !srcPath.Any() )
                throw new ArgumentException( "Path can't be empty", nameof( srcPath ) );

            if ( width < 0 )
                throw new ArgumentException( "Width must be greater than 0", nameof( width ) );

            if ( height < 0 )
                throw new ArgumentException( "Height must be greater than 0", nameof( height ) );

            if ( position < 0 || position > _documentItems.Count - 1 )
                throw new ArgumentOutOfRangeException( nameof( position ) );

            _documentItems.Add()
        }

        public void InsertImage( int width, int height, string srcPath )
        {
            throw new NotImplementedException();
        }

        public void InsertParagraph( string text, int position )
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Save( string path )
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
