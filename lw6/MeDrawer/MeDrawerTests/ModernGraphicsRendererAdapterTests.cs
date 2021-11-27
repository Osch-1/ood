using Xunit;
using System;
using MeDrawer;
using System.IO;
using ModernGraphicsLib;
using System.Text;

namespace MeDrawerTests
{
    public class ModernGraphicsRendererAdapterTests
    {
        [Fact]
        public void ModernGraphicsRendererAdapter_Ctor_Null_ArgumentNullException()
        {
            //Arrange
            ModernGraphicsRendererAdapter modernGraphicsRendererAdapter;

            //Act
            void CallModernGraphicsRendererAdapterCtorWithNullParam()
            {
                modernGraphicsRendererAdapter = new( null );
            }

            //Assert
            Assert.Throws<ArgumentNullException>( CallModernGraphicsRendererAdapterCtorWithNullParam );
        }

        [Fact]
        public void ModernGraphicsRendererAdapter_MoveTo_TwoOnAbscissTwoOnOrdinate_CorrectTextInStream()
        {
            //Arrange
            ModernGraphicsRendererAdapter rendererAdapter;

            //Act
            using ( rendererAdapter = CreateModernGraphicsRendererAdapter() )
            {
                rendererAdapter.MoveTo( 2, 2 );
                Point currPoint = ( Point )typeof( ModernGraphicsRendererAdapter ).GetField( "_currentPoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance ).GetValue( rendererAdapter );

                //Assert
                Assert.Equal( new Point( 2, 2 ), currPoint );
            }
        }

        [Fact]
        public void ModernGraphicsRendererAdapter_LineTo_OneOnAbscissOneOnOrdinate_CorrectTextInStream()
        {
            //Arrange
            MemoryStream ms = new();
            ModernGraphicsRendererAdapter rendererAdapter;

            //Act
            using ( rendererAdapter = new( new( ms ) ) )
            {
                rendererAdapter.LineTo( 1, 1 );

                //Assert
                var currPoint = typeof( ModernGraphicsRendererAdapter ).GetField( "_currentPoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance ).GetValue( rendererAdapter );
                Assert.Equal( new Point( 1, 1 ), currPoint );
            }

            var streamValue = Encoding.UTF8.GetString( ms.GetBuffer() )[ 0..99 ];
            Assert.Equal( "<draw><line fromX=\"0\" fromY=\"0\" toX=\"1\" toY=\"1\">\n  <color r=\"0\" g=\"0\" b=\"0\" a=\"1\" />\n</line></draw>", streamValue );
        }

        [Fact]
        public void ModernGraphicsRendererAdapter_SetColor_NegativeNumber_ThrowsArgumentOutOfRangeException()
        {
            MemoryStream ms = new();
            ModernGraphicsRendererAdapter rendererAdapter = new( new( ms ) );

            //Act
            void setColorByNegativeNumber() => rendererAdapter.SetColor( -835 );

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>( setColorByNegativeNumber );
        }

        [Fact]
        public void ModernGraphicsRendererAdapter_LineTo_OneOnAbscissOneOnOrdinateWithSettedUpColor_CorrectTextInStream()
        {
            //Arrange
            MemoryStream ms = new();
            ModernGraphicsRendererAdapter rendererAdapter;

            //Act
            using ( rendererAdapter = new( new( ms ) ) )
            {
                rendererAdapter.SetColor( 65535 );
                rendererAdapter.LineTo( 1, 1 );

                //Assert
                var currPoint = typeof( ModernGraphicsRendererAdapter ).GetField( "_currentPoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance ).GetValue( rendererAdapter );
                Assert.Equal( new Point( 1, 1 ), currPoint );
            }

            var streamValue = Encoding.UTF8.GetString( ms.GetBuffer() )[ 0..103 ];
            Assert.Equal( "<draw><line fromX=\"0\" fromY=\"0\" toX=\"1\" toY=\"1\">\n  <color r=\"0\" g=\"255\" b=\"255\" a=\"1\" />\n</line></draw>", streamValue );
        }

        private static ModernGraphicsRendererAdapter CreateModernGraphicsRendererAdapter()
        {
            MemoryStream ms = new();
            ModernGraphicsRendererAdapter rendererAdapter = new( new( ms ) );
            return rendererAdapter;
        }
    }
}
