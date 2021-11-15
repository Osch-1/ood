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
        private readonly IShapeFactory _shapeFactory;

        public Designer( IShapeFactory shapeFactory )
        {
            _shapeFactory = shapeFactory;
        }

        public PictureDraft CreateDraft( List<string> shapesDescriptions )
        {
            if ( shapesDescriptions is null )
            {
                throw new ArgumentNullException( nameof( shapesDescriptions ) );
            }

            PictureDraft pictureDraft = new();

            foreach ( var shapeDescription in shapesDescriptions )
            {
                try
                {                    
                    pictureDraft.AddShape( _shapeFactory.CreateShape( shapeDescription ) );
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
