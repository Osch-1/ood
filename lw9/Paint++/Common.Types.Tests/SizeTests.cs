using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Common.Types.Tests;

public class SizeTests
{
    private const double _commonWidth = 10;
    private const double _commonHeight = 15;

    [Fact]
    public void Size_Ctor_CorrctlyInitializeFields()
    {
        //Arrange
        Size size;

        //Act
        size = new Size( _commonWidth, _commonHeight );

        //Assert
        Assert.Equal( _commonWidth, size.Width );
        Assert.Equal( _commonHeight, size.Height );
    }

    [Fact]
    public void Size_SetWidth_SetsWidthToProvidedValue()
    {
        //Arrange
        Size size = CreateSizeWithInitializedParameters();

        //Act
        size.SetWidth( 30 );

        //Assert
        Assert.Equal( 30, size.Width );
        Assert.Equal( _commonHeight, size.Height );
    }

    [Fact]
    public void Size_SetHeight_SetsWidthToProvidedValue()
    {
        //Arrange
        Size size = CreateSizeWithInitializedParameters();

        //Act
        size.SetHeight( 30 );

        //Assert
        Assert.Equal( _commonWidth, size.Width );
        Assert.Equal( 30, size.Height );
    }

    private static Size CreateSizeWithInitializedParameters()
    {
        return new Size( _commonWidth, _commonHeight );
    }
}
