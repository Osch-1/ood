using System;
using ArtDesigner.Canvas;
using ArtDesigner.Models;

namespace ArtDesigner
{
    public static class Painter
    {
        public static void DrawPicture( PictureDraft draft, ICanvas canvas )
        {
            if ( draft is null )
            {
                throw new ArgumentNullException( nameof( draft ) );
            }

            if ( canvas is null )
            {
                throw new ArgumentNullException( nameof( canvas ) );
            }

            foreach ( var shape in draft.Shapes )
            {
                shape.Draw( canvas );
            }
        }
    }
}
