using System;
using ArtDesigner.Models;
using ArtDesigner.Canvas;
using ArtDesigner.Factories;
using System.Collections.Generic;

namespace ArtDesigner
{
    public class Program
    {
        static void Main( string[] args )
        {
            string buffer = string.Empty;
            List<string> descriptions = new();

            while ( true )
            {
                buffer = Console.ReadLine();
                if ( buffer == "Draft" )
                    break;

                descriptions.Add( buffer );
            }

            ICanvas canvas = new InfoPrintingCanvas();
            IShapeFactory shapeFactory = new ShapeFactory();
            IDesigner designer = new Designer( shapeFactory );

            try
            {
                PictureDraft pictureDraft = designer.CreateDraft( descriptions );
                Painter.DrawPicture( pictureDraft, canvas );
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"An error occured while trying to create picture: {ex.Message}" );
            }
        }
    }
}
