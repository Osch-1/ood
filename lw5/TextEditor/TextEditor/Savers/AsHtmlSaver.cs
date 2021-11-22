using System.Collections.Generic;
using System.IO;
using System.Text;
using TextEditor.Converters.DocumentItemsConverter;
using TextEditor.DocumentItems;
using TextEditor.Extensions;

namespace TextEditor.Savers
{
    public class AsHtmlSaver : IDocumentSaver
    {
        private IDocumentItemConverter _converter = new HtmlDocumentItemsConverter();

        public void Save( string title, List<IDocumentItem> items, string path )
        {
            using FileStream fs = File.Create( $"{PathUtils.NormalizePath( path )}TextEditor/index.html" );
            string body = _converter.Convert( items );
            byte[] value = new UTF8Encoding( true ).GetBytes( GetDocumentValue( HtmlUtil.EncodeText( title ), body ) );
            fs.Write( value, 0, value.Length );

            SetupStyleCss( path );

            MoveContent( path, items );
        }

        private void SetupStyleCss( string path )
        {
            using FileStream fs = File.Create( $"{PathUtils.NormalizePath( path )}TextEditor/style.css" );
            byte[] value = new UTF8Encoding( true ).GetBytes( "body { margin: 0 auto; display: flex; justify-content: center; }  p {max-width:500px; text-align:center;}" );
            fs.Write( value, 0, value.Length );
        }

        private void MoveContent( string path, List<IDocumentItem> items )
        {
            foreach ( var item in items )
            {
                if ( item.GetItemType() == DocumentItemType.Image )
                {
                    var destPath = $"{path}/TextEditor/{TextEditorSettings.ImagesSubDirectory}";
                    Directory.CreateDirectory( destPath );
                    File.Copy( item.Image.Path, $"{destPath}/{item.Image.Name}" );
                }
            }
        }

        private string GetDocumentValue( string title, string body )
        {
            return $"<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><meta http-equiv=\"X-UA-Compatible\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"><link rel=\"stylesheet\" href=\"style.css\"><title>{title}</title></head><body><div style=\"display: flex; flex-direction: column;\">{body}</div></body></html>";
        }
    }
}
