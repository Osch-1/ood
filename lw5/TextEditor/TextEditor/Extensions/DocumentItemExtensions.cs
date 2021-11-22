using TextEditor.DocumentItems;

namespace TextEditor.Extensions
{
    public static class DocumentItemExtensions
    {
        public static DocumentItemType GetItemType( this IDocumentItem documentItem )
        {
            if ( documentItem.Image is not null )
                return DocumentItemType.Image;

            if ( documentItem.Paragraph is not null )
                return DocumentItemType.Paragrpah;

            return DocumentItemType.Unknown;
        }
    }
    
}
