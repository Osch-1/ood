using TextEditor;
using TextEditor.DocumentItems;

namespace TextEditorTests
{
    public class TestDocument : IDocument
    {
        private string _title;

        public int ItemsCount => throw new System.NotImplementedException();

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public bool CanUndo => throw new System.NotImplementedException();

        public bool CanRedo => throw new System.NotImplementedException();

        public void DeleteItem( int index )
        {
            throw new System.NotImplementedException();
        }

        public IDocumentItem GetItem( int index )
        {
            throw new System.NotImplementedException();
        }

        public void InsertImage( int width, int height, string srcPath, int position )
        {
            throw new System.NotImplementedException();
        }

        public void InsertImage( int width, int height, string srcPath )
        {
            throw new System.NotImplementedException();
        }

        public void InsertParagraph( string text, int position )
        {
            throw new System.NotImplementedException();
        }

        public void Redo()
        {
            throw new System.NotImplementedException();
        }

        public void Save( string path )
        {
            throw new System.NotImplementedException();
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}
