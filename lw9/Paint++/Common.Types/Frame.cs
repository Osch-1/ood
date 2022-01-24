namespace Common.Types;

public struct Frame
{
    private Point _leftTop;
    private Size _size;

    public Point LeftTop => _leftTop;
    public double Width => _size.Width;
    public double Height => _size.Height;


    public Frame( Point leftTop, Size size )
    {
        _leftTop = leftTop;
        _size = size;
    }

    public Frame( Point leftTop, double width, double height )
    {
        _leftTop = leftTop;
        _size = new Size( width, height );
    }

    public void SetLeftTop( Point point )
    {
        _leftTop = point;
    }

    public void SetWidth( double width )
    {
        _size.SetWidth( width );
    }

    public void SetHeight( double height )
    {
        _size.SetHeight( height );
    }

    public static Frame Default => new( Point.Default, Size.Default );
}
