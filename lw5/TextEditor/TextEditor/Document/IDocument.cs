using System.IO;
using TextEditor.DocumentItems;

namespace TextEditor
{
    public interface IDocument
    {
        public int ItemsCount
        {
            get;
        }

        public string Title
        {
            get;
            set;
        }

        public bool CanUndo
        {
            get;
        }

        public bool CanRedo
        {
            get;
        }

        public void InsertParagraph( string text, int position );

        public void InsertImage( int width, int height, string srcPath, int position );

        public void InsertImage( int width, int height, string srcPath );

        public IDocumentItem GetItem( int index );

        public void DeleteItem( int index );

        public void Undo();

        public void Redo();

        public void Save( string path );
    }
}
