namespace TextEditor.DocumentItems.Image
{
    public interface IImage
    {
        public string Path
        {
            get;
        }

        public int Width
        {
            get;
        }

        public int Height
        {
            get;
        }

        public string Name
        {
            get;
        }

        public void Resize( int width, int height );
    }
}
