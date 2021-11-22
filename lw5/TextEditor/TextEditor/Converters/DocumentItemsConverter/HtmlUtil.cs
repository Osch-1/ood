using System.Text;

namespace TextEditor.Converters.DocumentItemsConverter
{
    public static class HtmlUtil
    {
        public static string EncodeText( string text )
        {
            StringBuilder sb = new();
            foreach ( var ch in text )
            {
                sb.Append( EncodeSymbol( ch ) );
            }

            return sb.ToString();
        }

        private static string EncodeSymbol( char symbol )
        {
            string encodedValue = "";

            switch ( symbol )
            {
                case '<':
                    encodedValue = "lt";
                    break;
                case '>':
                    encodedValue = "gt";
                    break;
                case '\'':
                    encodedValue = "bsol";
                    break;
                case '"':
                    encodedValue = "quot";
                    break;
                case '&':
                    encodedValue = "amp";
                    break;
                default:
                    return symbol.ToString();
            }

            return $"&{encodedValue};";
        }
    }
}