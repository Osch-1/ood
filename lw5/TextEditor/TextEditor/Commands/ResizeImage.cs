using System;
using TextEditor.DocumentItems.Image;

namespace TextEditor.Commands
{
    public class ResizeImage : AbstractCommand
    {
        private readonly IImage _image;
        private int _widthTemp;
        private int _heightTemp;

        public ResizeImage( IImage image, int width, int height )
            : base()
        {
            _image = image ?? throw new ArgumentNullException( nameof( image ) );
            _widthTemp = width;
            _heightTemp = height;
        }

        protected override void DoInvoke()
        {
            base.DoInvoke();
            ResizeImageAndSaveTempValues();
        }

        protected override void DoUndo()
        {
            base.DoUndo();
            ResizeImageAndSaveTempValues();
        }

        private void ResizeImageAndSaveTempValues()
        {
            int width = _image.Width;
            int height = _image.Height;

            _image.Resize( _widthTemp, _heightTemp );

            _widthTemp = width;
            _heightTemp = height;
        }
    }
}
