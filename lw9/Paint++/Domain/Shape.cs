using Common.Types;
using Domain.EventModel;

namespace Domain;

public class Shape
{
    private Frame _frame;
    private ShapeType _shapeType;

    public Frame Frame => _frame;
    public ShapeType ShapeType => _shapeType;

    public Shape( Frame frame, ShapeType shapeType )
    {
        _frame = frame ?? throw new ArgumentNullException( nameof( frame ) );
        _shapeType = shapeType;
    }

    public void SetLeftTopX( double value )
    {
        if ( _frame.LeftTop.X != value )
        {
            Point newPoint = _frame.LeftTop;
            newPoint.SetAbscissa( value );
            _frame.SetLeftTop( newPoint );
            OnPropertyChanged( "LeftTopX" );
        }
    }

    public void SetLeftTopY( double value )
    {
        if ( _frame.LeftTop.Y != value )
        {
            Point newPoint = _frame.LeftTop;
            newPoint.SetOrdinate( value );
            _frame.SetLeftTop( newPoint );
            OnPropertyChanged( "LeftTopY" );
        }
    }

    public void SetWidth( double value )
    {
        if ( _frame.Width != value )
        {
            _frame.SetWidth( value );
            OnPropertyChanged( "Width" );
        }
    }

    public void SetHeight( double value )
    {
        if ( _frame.Width != value )
        {
            _frame.SetHeight( value );
            OnPropertyChanged( "Height" );
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged( string propertyName )
    {
        PropertyChanged.Invoke( this, new PropertyChangeEventArguments( propertyName ) );
    }
}
