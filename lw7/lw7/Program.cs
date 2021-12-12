using lw7;
using lw7.Shapes;

ICanvas canvas = new Canvas();

Rectangle walls = new( new( 225, 50 ), 50, 50 );
walls.FillStyle.Color = new( 252, 186, 3, 1 );
Rectangle windows = new( new( 245, 70 ), 10, 10 );
walls.FillStyle.Color = new( 3, 53, 252, 1 );
Ellipse sun = new( new( 450, 500 ), 15, 15 );
sun.FillStyle.Color = new( 252, 248, 3, 1 );

CompositeShape house = new( new List<IShape> { walls, windows } );

Slide slide = new Slide( 500, 500 );
slide.AddShape( house );
slide.AddShape( sun );

slide.Draw( canvas );