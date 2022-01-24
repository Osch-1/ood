using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Common.Types.Tests;

public class PointTests
{
    private const double _commonAbscissValue = 12;
    private const double _commonOrdinateValue = 7;

    [Fact]
    public void Point_Default_ReturnsPointWithExpectedValues()
    {
        //Arrange
        const double expectedAbsciss = 0;
        const double expectedOrdinate = 0;
        Point point;

        //Act
        point = Point.Default;

        //Assert
        Assert.Equal( expectedAbsciss, point.X );
        Assert.Equal( expectedOrdinate, point.Y );
    }

    [Fact]
    public void Point_Ctor_CorrectFieldsInitialization()
    {
        //Arrange
        Point point;

        //Act
        point = new Point( _commonAbscissValue, _commonOrdinateValue );

        //Assert
        Assert.Equal( _commonAbscissValue, point.X );
        Assert.Equal( _commonOrdinateValue, point.Y );
    }

    [Fact]
    public void Point_SetAbscissa_SetsAbscissaToProvidedValue()
    {
        //Arrange
        Point point = Point.Default;

        //Act
        point.SetAbscissa( _commonAbscissValue );

        //Assert
        Assert.Equal( _commonAbscissValue, point.X );
        Assert.Equal( Point.DefaultAbsciss, point.Y );
    }
}
