using System.Collections.Generic;
using lw7;
using lw7.Shapes;
using NUnit.Framework;

namespace lw7Tests.Shapes
{
    //add test for self insert
    public class CompositeShapeTests
    {
        [Test]
        public void CompositeShape_Ctor_FourElements_CorrectlySetsState()
        {
            //Arrange
            CompositeShape composite;

            //Act
            composite = GetSetupedCompositeShape();

            //Assert            
            Assert.That( composite.Composite, Is.EqualTo( composite ) );

            //Assert frame
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 30 ) );
            Assert.That( frame.Height, Is.EqualTo( 15 ) );

            //Assert stored shapes
            Assert.That( composite.ShapesCount, Is.EqualTo( 4 ) );
            var shape = composite.GetShapeAt( 0 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 10 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 1 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 2 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 0 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 3 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( -10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            //assert fill style
            var fillStyle = composite.FillStyle;
            Assert.NotNull( fillStyle );
            Assert.That( fillStyle.IsEnabled, Is.True );
            Assert.That( fillStyle.Color, Is.EqualTo( new RGBAColor( 0, 0, 0, 1 ) ) );

            //assert border style            
            var borderStyle = composite.BorderStyle;
            Assert.NotNull( borderStyle );
            Assert.That( borderStyle.IsEnabled, Is.True );
            Assert.That( borderStyle.Color, Is.EqualTo( new RGBAColor( 0, 0, 0, 1 ) ) );
            Assert.That( borderStyle.BorderHeight, Is.EqualTo( 1 ) );
        }

        [Test]
        public void CompositeShape_AddShape_WithNewMaxY_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.AddShape( new Rectangle( new Point( 0, 15 ), 10, 5 ) );

            //Assert
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 15 ) );
            Assert.That( frame.Width, Is.EqualTo( 30 ) );
            Assert.That( frame.Height, Is.EqualTo( 20 ) );
        }

        [Test]
        public void CompositeShape_AddShape_WithNewMinY_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.AddShape( new Rectangle( new Point( 0, -5 ), 10, 5 ) );

            //Assert
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 30 ) );
            Assert.That( frame.Height, Is.EqualTo( 20 ) );
        }

        [Test]
        public void CompositeShape_AddShape_WithNewMaxX_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.AddShape( new Rectangle( new Point( 20, 10 ), 10, 5 ) );

            //Assert
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 40 ) );
            Assert.That( frame.Height, Is.EqualTo( 15 ) );
        }

        [Test]
        public void CompositeShape_AddShape_WithNewMinX_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.AddShape( new Rectangle( new Point( -20, 10 ), 10, 5 ) );

            //Assert
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -20 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 40 ) );
            Assert.That( frame.Height, Is.EqualTo( 15 ) );
        }

        [Test]
        public void CompositeShape_RemoveAt_ShapeWithMaxY_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.RemoveShape( 0 );

            //Assert
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 5 ) );
            Assert.That( frame.Width, Is.EqualTo( 30 ) );
            Assert.That( frame.Height, Is.EqualTo( 10 ) );
        }

        [Test]
        public void CompositeShape_RemoveAt_ShapeWithMinY_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.RemoveShape( 2 );

            //Assert
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 30 ) );
            Assert.That( frame.Height, Is.EqualTo( 10 ) );
        }

        [Test]
        public void CompositeShape_RemoveAt_ShapeWithMaxX_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.RemoveShape( 1 );

            //Assert
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 20 ) );
            Assert.That( frame.Height, Is.EqualTo( 15 ) );
        }

        [Test]
        public void CompositeShape_RemoveAt_ShapeWithMinX_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.RemoveShape( 3 );

            //Assert
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( 0 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 20 ) );
            Assert.That( frame.Height, Is.EqualTo( 15 ) );
        }

        //cases:
        //horizontal grow
        [Test]
        public void CompositeShape_SetFrame_HorizontalGrow_CorrectShapeScailing()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.SetFrame( new Frame( composite.Frame.LeftTopX, composite.Frame.LeftTopY, composite.Frame.Width * 2, composite.Frame.Height ) );

            //Assert frame
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 60 ) );
            Assert.That( frame.Height, Is.EqualTo( 15 ) );

            //Assert stored shapes
            Assert.That( composite.ShapesCount, Is.EqualTo( 4 ) );
            var shape = composite.GetShapeAt( 0 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 10 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 20 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 1 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 20 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 2 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 0 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 20 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 3 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( -10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 20 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );
        }

        //horizontal decrease
        [Test]
        public void CompositeShape_SetFrame_HorizontalDecrease_CorrectShapeScailing()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.SetFrame( new Frame( composite.Frame.LeftTopX, composite.Frame.LeftTopY, composite.Frame.Width * 0.5, composite.Frame.Height ) );

            //Assert frame
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 15 ) );
            Assert.That( frame.Height, Is.EqualTo( 15 ) );

            //Assert stored shapes
            Assert.That( composite.ShapesCount, Is.EqualTo( 4 ) );
            var shape = composite.GetShapeAt( 0 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 10 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 5 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 1 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 5 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 2 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 0 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 5 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 3 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( -10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 5 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );
        }

        //vertical grow
        [Test]
        public void CompositeShape_SetFrame_VerticalGrow_CorrectShapeScailing()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.SetFrame( new Frame( composite.Frame.LeftTopX, composite.Frame.LeftTopY, composite.Frame.Width, composite.Frame.Height * 2 ) );

            //Assert frame
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 30 ) );
            Assert.That( frame.Height, Is.EqualTo( 30 ) );

            //Assert stored shapes
            Assert.That( composite.ShapesCount, Is.EqualTo( 4 ) );
            var shape = composite.GetShapeAt( 0 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 10 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 10 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 1 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 10 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 2 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 0 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 10 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 3 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( -10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 10 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );
        }

        //vertical decrease
        [Test]
        public void CompositeShape_SetFrame_VerticalDecrease_CorrectShapeScailing()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.SetFrame( new Frame( composite.Frame.LeftTopX, composite.Frame.LeftTopY, composite.Frame.Width, composite.Frame.Height * 0.5 ) );

            //Assert frame
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -10 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 10 ) );
            Assert.That( frame.Width, Is.EqualTo( 30 ) );
            Assert.That( frame.Height, Is.EqualTo( 7.5 ) );

            //Assert stored shapes
            Assert.That( composite.ShapesCount, Is.EqualTo( 4 ) );
            var shape = composite.GetShapeAt( 0 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 10 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 2.5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 1 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 2.5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 2 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 0, 0 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 2.5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 3 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( -10, 5 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 2.5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );
        }

        //move
        [Test]
        public void CompositeShape_SetFrame_PositionMove_CorrectShapeScailing()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.SetFrame( new Frame( composite.Frame.LeftTopX + 3, composite.Frame.LeftTopY + 4, composite.Frame.Width, composite.Frame.Height ) );

            //Assert frame
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -7 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 14 ) );
            Assert.That( frame.Width, Is.EqualTo( 30 ) );
            Assert.That( frame.Height, Is.EqualTo( 15 ) );

            //Assert stored shapes
            Assert.That( composite.ShapesCount, Is.EqualTo( 4 ) );
            var shape = composite.GetShapeAt( 0 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 3, 14 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 1 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 13, 9 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 2 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 3, 4 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 3 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( -7, 9 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 10 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );
        }

        //move + horizontal effect + vertical effect
        [Test]
        public void CompositeShapeSetFrame_PositionMoveAndBothAxisScailing_CorrectState()
        {
            //Arrange
            CompositeShape composite = GetSetupedCompositeShape();

            //Act
            composite.SetFrame( new Frame( composite.Frame.LeftTopX + 3, composite.Frame.LeftTopY + 4, composite.Frame.Width * 2, composite.Frame.Height * 0.5 ) );

            //Assert frame
            var frame = composite.Frame;
            Assert.IsNotNull( frame );
            Assert.That( frame.LeftTopX, Is.EqualTo( -7 ) );
            Assert.That( frame.LeftTopY, Is.EqualTo( 14 ) );
            Assert.That( frame.Width, Is.EqualTo( 60 ) );
            Assert.That( frame.Height, Is.EqualTo( 7.5 ) );

            //Assert stored shapes
            Assert.That( composite.ShapesCount, Is.EqualTo( 4 ) );
            var shape = composite.GetShapeAt( 0 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 3, 14 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 20 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 2.5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 1 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 13, 9 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 20 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 2.5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 2 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( 3, 4 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 20 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 2.5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );

            shape = composite.GetShapeAt( 3 );
            Assert.NotNull( shape );
            Assert.That( shape.Frame.LeftTop, Is.EqualTo( new Point( -7, 9 ) ) );
            Assert.That( shape.Frame.Width, Is.EqualTo( 20 ) );
            Assert.That( shape.Frame.Height, Is.EqualTo( 2.5 ) );
            Assert.That( shape.Parent, Is.EqualTo( composite ) );
        }

        private static CompositeShape GetSetupedCompositeShape()
        {
            Rectangle rectangle1 = new( new( 0, 10 ), 10, 5 );
            Rectangle rectangle2 = new( new( 10, 5 ), 10, 5 );
            Rectangle rectangle3 = new( new( 0, 0 ), 10, 5 );
            Rectangle rectangle4 = new( new( -10, 5 ), 10, 5 );
            CompositeShape composite = new( new List<IShape> { rectangle1, rectangle2, rectangle3, rectangle4 } );

            return composite;
        }
    }
}
