using System;
using System.Collections.Generic;
using System.Text;
using TextEditor.DocumentItems;
using TextEditor.DocumentItems.Image;
using TextEditor.DocumentItems.Paragraph;
using TextEditor.Extensions;

namespace TextEditor.Converters.DocumentItemsConverter
{
    public class HtmlDocumentItemsConverter : IDocumentItemConverter
    {
        public string Convert( List<IDocumentItem> documentItems )
        {
            if ( documentItems is null )
            {
                throw new ArgumentNullException( nameof( documentItems ) );
            }

            StringBuilder sb = new();

            foreach ( var documentItem in documentItems )
            {
                sb.Append( Convert( documentItem ) );
            }

            return sb.ToString();
        }

        private string Convert( IDocumentItem documentItem )
        {
            switch ( documentItem.GetItemType() )
            {
                case DocumentItemType.Image:
                    return Convert( documentItem.Image );
                case DocumentItemType.Paragrpah:
                    return Convert( documentItem.Paragraph );
                case DocumentItemType.Unknown:
                default:
                    throw new ArgumentException( "Unknown document item" );
            }
        }

        private string Convert( IImage image )
        {
            return $"<img src=\"{PathUtils.GetImageSubDirWithName( image.Path )}\" width=\"{image.Width}\" height=\"{image.Height}\">";
        }

        private string Convert( IParagraph paragraph )
        {
            string encodedText = HtmlUtil.EncodeText( paragraph.Text );
            return $"<p>{encodedText}</p>";
        }
    }
}
