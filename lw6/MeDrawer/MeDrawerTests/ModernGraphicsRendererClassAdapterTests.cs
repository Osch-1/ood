using Xunit;
using System;
using MeDrawer;
using System.IO;
using ModernGraphicsLib;
using System.Text;

namespace MeDrawerTests
{
    public class ModernGraphicsRendererClassAdapterTests
    {
        [Fact]
        public void ModernGraphicsRendererClassAdapter_Ctor_Null_ArgumentNullException()
        {
            //Arrange
            ModernGraphicsRendererClassAdapter modernGraphicsRendererClassAdapter;

            //Act
            void CallModernGraphicsRendererClassAdapterCtorWithNullParam()
            {
                modernGraphicsRendererClassAdapter = new( null );
            }

            //Assert
            Assert.Throws<ArgumentNullException>( CallModernGraphicsRendererClassAdapterCtorWithNullParam );
        }

        [Fact]
        public void ModernGraphicsRendererClassAdapter_MoveTo_TwoOnAbscissTwoOnOrdinate_CorrectTextInStream()
        {
            //Arrange
            ModernGraphicsRendererClassAdapter rendererAdapter;

            //Act
            using ( rendererAdapter = CreateModernGraphicsRendererClassAdapter() )
            {
                rendererAdapter.MoveTo( 2, 2 );
                Point currPoint = ( Point )typeof( ModernGraphicsRendererClassAdapter ).GetField( "_currentPoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance ).GetValue( rendererAdapter );

                //Assert
                Assert.Equal( new Point( 2, 2 ), currPoint );
            }
        }

        [Fact]
        public void ModernGraphicsRendererClassAdapter_LineTo_OneOnAbscissOneOnOrdinate_CorrectTextInStream()
        {
            //Arrange
            MemoryStream ms = new();
            ModernGraphicsRendererClassAdapter rendererAdapter;

            //Act
            using ( rendererAdapter = new( ms ) )
            {
                rendererAdapter.LineTo( 1, 1 );

                //Assert
                var currPoint = typeof( ModernGraphicsRendererClassAdapter ).GetField( "_currentPoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance ).GetValue( rendererAdapter );
                Assert.Equal( new Point( 1, 1 ), currPoint );
            }

            var streamValue = Encoding.UTF8.GetString( ms.GetBuffer() )[ 0..57 ];
            Assert.Equal( "<draw><line fromX=\"0\" fromY=\"0\" toX=\"1\" toY=\"1\"/\n></draw>", streamValue );
        }

        private static ModernGraphicsRendererClassAdapter CreateModernGraphicsRendererClassAdapter()
        {
            MemoryStream ms = new();
            ModernGraphicsRendererClassAdapter rendererAdapter = new( ms );
            return rendererAdapter;
        }
    }
}
