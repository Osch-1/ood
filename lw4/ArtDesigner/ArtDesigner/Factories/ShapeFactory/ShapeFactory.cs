using System;
using System.Linq;
using ArtDesigner.Shapes;
using ArtDesigner.Primitives;
using System.Collections.Generic;

namespace ArtDesigner.Factories
{
    public class ShapeFactory : IShapeFactory
    {
        private static readonly HashSet<string> _supportedShapes = new() { "Ellipse", "Rectangle", "RegularPolygon", "Triangle" };
        public IShape CreateShape( string description )
        {
            var parameters = description.Split( ' ' );

            string shapeType = parameters[ 0 ];
            if ( _supportedShapes.Contains( shapeType ) )
            {
                return CreateShape( shapeType, parameters[ 1.. ].ToList() );
            }
            else
            {
                throw new ArgumentException( "Unknown shape type" );
            }
        }

        private IShape CreateShape( string shapeType, List<string> parameters )
        {
            return shapeType switch
            {
                "Ellipse" => CreateEllipse( parameters ),
                "Rectangle" => CreateRectangle( parameters ),
                "RegularPolygon" => CreateRegularPolygon( parameters ),
                "Triangle" => CreateTriangle( parameters ),
                _ => throw new ArgumentException( nameof( shapeType ) ),
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
