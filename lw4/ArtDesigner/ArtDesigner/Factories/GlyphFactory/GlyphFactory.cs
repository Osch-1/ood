using System;
using System.Linq;
using ArtDesigner.Shapes;
using ArtDesigner.Primitives;
using System.Collections.Generic;

namespace ArtDesigner.Factories
{
    public class GlyphFactory : IGlyphFactory
    {
        private static readonly HashSet<string> _supportedGlyphs = new() { "Ellipse", "Rectangle", "RegularPolygon", "Triangle" };

        public IGlyph Create( string description )
        {
            var parameters = description.Split( ' ' );

            string glyphType = parameters[ 0 ];
            if ( _supportedGlyphs.Contains( glyphType ) )
            {
                return CreateGlyph( glyphType, parameters[ 1.. ].ToList() );
            }
            else
            {
                throw new ArgumentException( "Unknown shape type" );
            }
        }

        private IGlyph CreateGlyph( string glyphType, List<string> parameters )
        {
            return glyphType switch
            {
                "Ellipse" => CreateEllipse( parameters ),
                "Rectangle" => CreateRectangle( parameters ),
                "RegularPolygon" => CreateRegularPolygon( parameters ),
                "Triangle" => CreateTriangle( parameters ),
                _ => throw new ArgumentException( nameof( glyphType ) ),
            };
        }

        private Ellipse CreateEllipse( List<string> parameters )    
        {
            if ( parameters.Count < 5 )
                throw new ArgumentException();

            return new Ellipse( Enum.Parse<Color>( parameters[ 0 ] ),
                                new( double.Parse( parameters[ 1 ] ), double.Parse( parameters[ 2 ] ) ),
                                int.Parse( parameters[ 3 ] ),
                                int.Parse( parameters[ 4 ] ) );
        }

        private Rectangle CreateRectangle( List<string> parameters )
        {
            if ( parameters.Count < 5 )
                throw new ArgumentException();

            return new Rectangle( Enum.Parse<Color>( parameters[ 0 ] ),
                                  new( double.Parse( parameters[ 1 ] ), double.Parse( parameters[ 2 ] ) ),
                                  int.Parse( parameters[ 3 ] ),
                                  int.Parse( parameters[ 4 ] ) );
        }

        private RegularPolygon CreateRegularPolygon( List<string> parameters )
        {
            if ( parameters.Count < 5 )
                throw new ArgumentException();

            return new RegularPolygon( Enum.Parse<Color>( parameters[ 0 ] ),
                                       new( double.Parse( parameters[ 1 ] ), double.Parse( parameters[ 2 ] ) ),
                                       int.Parse( parameters[ 3 ] ),
                                       int.Parse( parameters[ 4 ] ) );
        }

        private Triangle CreateTriangle( List<string> parameters )
        {
            if ( parameters.Count < 7 )
                throw new ArgumentException();

            return new Triangle( Enum.Parse<Color>( parameters[ 0 ] ),
                                 new( double.Parse( parameters[ 1 ] ), double.Parse( parameters[ 2 ] ) ),
                                 new( double.Parse( parameters[ 3 ] ), double.Parse( parameters[ 4 ] ) ),
                                 new( double.Parse( parameters[ 5 ] ), double.Parse( parameters[ 6 ] ) ) );
        }
    }
}
