using System;

namespace TextEditor.DocumentItems.Paragraph
{
    public class Paragraph : IParagraph
    {
        private string _text;

        public Paragraph( string text )
        {
            _text = text;
        }

        public string Text
        {
            get => _text;
            set
            {
                if ( value is null )
                    throw new ArgumentNullException();

                _text = value;
            }

        }
    }
}
