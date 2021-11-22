using System.Collections.Generic;
using TextEditor.DocumentItems;

namespace TextEditor.Converters.DocumentItemsConverter
{
    public interface IDocumentItemConverter
    {
        public string Convert( List<IDocumentItem> documentItems );
    }
}
