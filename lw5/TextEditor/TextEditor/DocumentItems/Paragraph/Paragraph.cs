using System;

namespace TextEditor.DocumentItems.Paragraph
{
    public class Paragraph : IParagraph
    {
        private string _text;

        public Paragraph( string text )
        {
            if ( text is null )
                throw new ArgumentNullException();

            _text = text;
        }

        public string Text
        {
            get => _text;
            set
            {
                if ( value is null )
                    throw new ArgumentNullException( "Text can't be null", nameof( value ) );

                _text = value;
            }
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
