using System;
using ArtDesigner.Shapes;
using System.Collections.Generic;

namespace ArtDesigner.Models
{
    public class PictureDraft
    {
        private List<IGlyph> _shapes = new();

        public IReadOnlyList<IGlyph> Shapes => _shapes;

        public void AddGlyph( IGlyph shape )
        {
            if ( shape is null )
            {
                throw new ArgumentNullException( nameof( shape ) );
            }

            _shapes.Add( shape );
        }
    }
}