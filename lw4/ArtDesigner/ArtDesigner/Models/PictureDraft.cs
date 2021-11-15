using System;
using ArtDesigner.Shapes;
using System.Collections.Generic;

namespace ArtDesigner.Models
{
    public class PictureDraft
    {
        private List<IShape> _shapes = new();

        public IReadOnlyList<IShape> Shapes => _shapes;

        public void AddShape( IShape shape )
        {
            if ( shape is null )
            {
                throw new ArgumentNullException( nameof( shape ) );
            }

            _shapes.Add( shape );
        }
    }
}