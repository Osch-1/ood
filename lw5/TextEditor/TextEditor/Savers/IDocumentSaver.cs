using System.Collections.Generic;
using TextEditor.DocumentItems;

namespace TextEditor.Savers
{
    public interface IDocumentSaver
    {
        public void Save( string title, List<IDocumentItem> items, string path );
    }
}
