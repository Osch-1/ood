namespace Common.Types;

public struct Point
{
    public const double DefaultAbsciss = 0;
    public const double DefaultOrdinate = 0;

    private double _x;
    private double _y;

    public double X => _x;
    public double Y => _y;

    public Point( double x, double y )
    {
        _x = x;
        _y = y;
    }

    public void SetAbscissa( double x )
    {
        _x = x;
    }

    public void SetOrdinate( double y )
    {
        _y = y;
    }

    public static Point Default
    {
        get
        {
            return new Point( DefaultAbsciss, DefaultOrdinate );
        }
    }
}
