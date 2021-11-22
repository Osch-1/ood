using MeDrawer;
using GraphicsLib;
using ShapeDrawingLib;
using ModernGraphicsLib;

void PaintPicture( CanvasPainter painter )
{
    Triangle triangle = new( new( 10, 15 ), new( 100, 200 ), new( 150, 250 ) );
    Rectangle rectangle = new( new( 30, 40 ), 18, 24 );

    painter.Draw( triangle );
    painter.Draw( rectangle );
}

void PaintPictureOnCanvas()
{
    ICanvas canvas = new Canvas();
    CanvasPainter painter = new( canvas );
    PaintPicture( painter );
}

void PaintPictureOnModernGraphicsRenderer()
{
    ModernGraphicsRenderer renderer = new( Console.OpenStandardOutput() );
    using var canvas = new ModernGraphicsRendererAdapter( renderer );
    CanvasPainter painter = new( canvas );
    PaintPicture( painter );
}

Console.WriteLine( "Should we use new API(Y/N)?" );

string answer = Console.ReadLine();
if ( answer is not null && answer.Equals( "y", StringComparison.InvariantCultureIgnoreCase ) )
{
    PaintPictureOnModernGraphicsRenderer();
}
else
{
    PaintPictureOnCanvas();
}