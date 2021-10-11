using TextEditor.DocumentItems.Image;
using TextEditor.DocumentItems.Paragraph;

namespace TextEditor.DocumentItems
{
    public class DocumentItem : IDocumentItem
    {
        private IImage _image;
        private IParagraph _paragraph;

        public DocumentItem( IImage image )
        {
            _image = image;
        }

        public DocumentItem( IParagraph paragraph )
        {
            _paragraph = paragraph;
        }

        public IImage Image => _image;

        public IParagraph Paragraph => _paragraph;
    }
}
