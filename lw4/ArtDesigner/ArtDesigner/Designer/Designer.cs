using System;
using ArtDesigner.Models;
using ArtDesigner.Factories;
using System.Collections.Generic;

namespace ArtDesigner
{
    public interface IDesigner
    {
        public PictureDraft CreateDraft( List<string> shapesDescriptions );
    }

    public class Designer : IDesigner
    {
        private readonly IGlyphFactory _shapeFactory;

        public Designer( IGlyphFactory shapeFactory )
        {
            _shapeFactory = shapeFactory;
        }

        public PictureDraft CreateDraft( List<string> glyphsDescriptions )
        {
            if ( glyphsDescriptions is null )
            {
                throw new ArgumentNullException( nameof( glyphsDescriptions ) );
            }

            PictureDraft pictureDraft = new();

            foreach ( var glyphDescription in glyphsDescriptions )
            {
                try
                {                    
                    pictureDraft.AddGlyph( _shapeFactory.Create( glyphDescription ) );
                }
                catch //( ShapeCreationByDescriptionException )
                {
                    //add exception hierarchy to prevent showing system errors to user
                    //other exception wont be thrown
                    throw;
                }
            }

            return pictureDraft;
        }
    }
}
