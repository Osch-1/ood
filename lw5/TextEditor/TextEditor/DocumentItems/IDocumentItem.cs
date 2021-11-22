using TextEditor.DocumentItems.Image;
using TextEditor.DocumentItems.Paragraph;

namespace TextEditor.DocumentItems
{
    public interface IDocumentItem
    {
        public IImage Image
        {
            get;
        }

        public IParagraph Paragraph
        {
            get;
        }
    }
}