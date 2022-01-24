using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Common.Types;

namespace Domain;

public class Canvas
{
    private ObservableCollection<Shape> _shapes;
    private Size _size;

    public INotifyCollectionChanged ShapesCollection => _shapes;

    public double Width => _size.Width;
    public double Height => _size.Height;

    public Canvas()
    {
        _shapes = new ObservableCollection<Shape>();
        _size = new Size( 640, 480 );
    }

    public Shape GetShape( int index )
    {
        if ( _shapes.Count >= index )
        {
            return _shapes[ index ];
        }

        throw new ArgumentOutOfRangeException( nameof( index ) );
    }

    public void AddShape( Shape shape )
    {
        _shapes.Add( shape );
    }

    public void InsertShape( Shape shape, int index )
    {
        if ( index < 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( index ) );
        }

        _shapes[ index ] = shape;
    }

    public void RemoveShape( int index )
    {
        _shapes.RemoveAt( index );
    }
}
