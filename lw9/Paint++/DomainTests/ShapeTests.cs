using Common.Types;
using Domain;
using Xunit;

namespace DomainTests;

public class ShapeTests
{
    [Fact]
    public void Shape_Ctor_CorrectlySetsParams()
    {
        //Arrange
        Shape shape;
        Frame frame = Frame.Default;

        //Act
        shape = new Shape( frame, ShapeType.Triangle );

        //Assert
        Assert.Equal( frame.Width, shape.Frame.Width );
        Assert.Equal( frame.Height, shape.Frame.Height );
        Assert.Equal( ShapeType.Triangle, shape.ShapeType );
    }
}