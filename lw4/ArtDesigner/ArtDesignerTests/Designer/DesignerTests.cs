using System;
using ArtDesigner;
using NUnit.Framework;
using ArtDesigner.Models;
using ArtDesigner.Shapes;
using ArtDesigner.Factories;
using ArtDesigner.Primitives;
using System.Collections.Generic;

namespace ArtDesignerTests
{
    public class DesignerTests
    {
        [Test]
        public void Designer_CreateDraft_CorrectDescriptionsList_ExpectedPictureDraft()
        {
            //Arrange
            IGlyphFactory shapeFactory = new GlyphFactory();
            Designer designer = new( shapeFactory );
            List<string> shapesDescriptions = new() { "Rectangle Red 0 5 10 5", "Ellipse Black 0 0 10 5", "RegularPolygon Black 0 0 5 3", "Triangle Red 0 0 0 5 5 0" };

            //Act
            PictureDraft draft = designer.CreateDraft( shapesDescriptions );

            //Assert
            Assert.IsNotNull( draft );
            Assert.That( draft.Shapes.Count, Is.EqualTo( 4 ) );

            var shape = draft.Shapes[ 0 ];
            Assert.That( shape, Is.Not.Null );
            Rectangle rectangle = shape as Rectangle;
            Assert.That( rectangle, Is.Not.Null );
            Assert.That( rectangle.LeftTop, Is.EqualTo( new Point( 0, 5 ) ) );
            Assert.That( rectangle.Width, Is.EqualTo( 10 ) );
            Assert.That( rectangle.Height, Is.EqualTo( 5 ) );

            shape = draft.Shapes[ 1 ];
            Assert.That( shape, Is.Not.Null );
            Ellipse ellipse = shape as Ellipse;
            Assert.That( ellipse, Is.Not.Null );
            Assert.That( rectangle.LeftTop, Is.EqualTo( new Point( 0, 5 ) ) );
            Assert.That( ellipse.HorizontalRadius, Is.EqualTo( 5 ) );
            Assert.That( ellipse.VerticalRadius, Is.EqualTo( 2.5 ) );

            shape = draft.Shapes[ 2 ];
            Assert.That( shape, Is.Not.Null );
            RegularPolygon polygon = shape as RegularPolygon;
            Assert.That( polygon, Is.Not.Null );
            Assert.That( polygon.Center, Is.EqualTo( new Point( 0, 0 ) ) );
            Assert.That( polygon.Radius, Is.EqualTo( 5 ) );
            Assert.That( polygon.VertexCount, Is.EqualTo( 3 ) );

            shape = draft.Shapes[ 3 ];
            Assert.That( shape, Is.Not.Null );
            Triangle triangle = shape as Triangle;
            Assert.That( triangle, Is.Not.Null );
            Assert.That( triangle.FirstVertex, Is.EqualTo( new Point( 0, 0 ) ) );
            Assert.That( triangle.SecondVertex, Is.EqualTo( new Point( 0, 5 ) ) );
            Assert.That( triangle.ThirdVertex, Is.EqualTo( new Point( 5, 0 ) ) );
        }

        [Test]
        public void Designer_CreateDraft_Null_ThrowsArgumentNullException()
        {
            //Arrange
            IGlyphFactory shapeFactory = new GlyphFactory();
            Designer designer = new( shapeFactory );

            //Act
            void CallCreateDraftWithNullArgument()
            {
                designer.CreateDraft( null );
            }

            //Assert
            Assert.Throws<ArgumentNullException>( CallCreateDraftWithNullArgument );
        }
    }
}
