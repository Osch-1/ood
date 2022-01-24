using Domain;

namespace Application;

public interface IShapeFactory
{
    public Shape Create( ShapeType shapeType );
}