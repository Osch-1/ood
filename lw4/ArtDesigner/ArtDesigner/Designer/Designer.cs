using ArtDesigner.Models;
using ArtDesigner.Factories;
using System.Collections.Generic;

namespace ArtDesigner
{
    public interface IDesigner
    {
        public PictureDraft CreateDraft( List<string> shapeDescriptions );
    }

    public class Designer : IDesigner
    {
        private readonly IShapeFactory _shapeFactory;

        public Designer( IShapeFactory shapeFactory )
        {
            _shapeFactory = shapeFactory;
        }

        public PictureDraft CreateDraft( List<string> shapeDescriptions )
        {
            PictureDraft pictureDraft = new();

            foreach ( var shapeDescription in shapeDescriptions )
            {
                try
                {                    
                    pictureDraft.AddShape( _shapeFactory.CreateShape( shapeDescription ) );
                }
                catch //( ShapeCreationByDescriptionException )
                {
                    //log error and continue, doesnt throw
                    //other exception will be thrown
                    throw;
                }
            }

            return pictureDraft;
        }
    }
}
