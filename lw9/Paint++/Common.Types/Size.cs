namespace Common.Types;

public struct Size
{
    private const int _defaultWidth = 150;
    private const int _defaultHeight = 150;

    private double _width;
    private double _height;

    public double Width => _width;
    public double Height => _height;

    public static Size Default
    {
        get
        {
            return new Size( _defaultWidth, _defaultHeight );
        }
    }

    public Size( double width, double height )
    {
        _width = width;
        _height = height;
    }

    public void SetWidth( double width )
    {
        _width = width;
    }

    public void SetHeight( double height )
    {
        _height = height;
    }
}
