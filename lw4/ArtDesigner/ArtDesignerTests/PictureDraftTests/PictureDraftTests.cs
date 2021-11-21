using System;
using NUnit.Framework;
using ArtDesigner.Models;

namespace ArtDesignerTests.PictureDraftTests
{
    public class PictureDraftTests
    {
        [Test]
        public void PictureDraft_AddShape_Null_ThrowsArgumentNullException()
        {
            //Arrange
            PictureDraft draft = new();

            //Act
            void AddNullShape()
            {
                draft.AddGlyph( null );
            }

            //Assert
            Assert.Throws<ArgumentNullException>( AddNullShape );
        }
    }
}
