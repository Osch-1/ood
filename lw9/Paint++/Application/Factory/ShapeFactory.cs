using Domain;
using Common.Types;

namespace Application;

public class ShapeFactory : IShapeFactory
{
    public Shape Create( ShapeType shapeType )
    {
        return new Shape( Frame.Default, shapeType );
    }
}
