using Common.Types;
using Domain.EventModel;

namespace Domain;

public class Shape
{
    private Frame _frame;
    private ShapeType _shapeType;

    public Frame Frame => _frame;
    public ShapeType ShapeType => _shapeType;

    public double LeftTopX
    {
        get
        {
            return _frame.LeftTop.X;
        }

        set
        {
            SetLeftTopX( value );
        }
    }

    public double LeftTopY
    {
        get
        {
            return _frame.LeftTop.Y;
        }

        set
        {
            SetLeftTopY( value );
        }
    }

    public double Width
    {
        get
        {
            return _frame.Width;
        }

        set
        {
            SetWidth( value );
        }
    }

    public double Height
    {
        get
        {
            return _frame.Height;
        }

        set
        {
            SetHeight( value );
        }
    }

    public Shape( Frame frame, ShapeType shapeType )
    {
        _frame = frame;
        _shapeType = shapeType;
    }

    private void SetLeftTopX( double value )
    {
        if ( _frame.LeftTop.X != value )
        {
            Point newPoint = _frame.LeftTop;
            newPoint.SetAbscissa( value );
            _frame.SetLeftTop( newPoint );
            OnPropertyChanged( nameof( LeftTopX ) );
        }
    }

    private void SetLeftTopY( double value )
    {
        if ( _frame.LeftTop.Y != value )
        {
            Point newPoint = _frame.LeftTop;
            newPoint.SetOrdinate( value );
            _frame.SetLeftTop( newPoint );
            OnPropertyChanged( nameof( LeftTopY ) );
        }
    }

    private void SetWidth( double value )
    {
        if ( _frame.Width != value )
        {
            _frame.SetWidth( value );
            OnPropertyChanged( nameof( Width ) );
        }
    }

    private void SetHeight( double value )
    {
        if ( _frame.Width != value )
        {
            _frame.SetHeight( value );
            OnPropertyChanged( nameof( Height ) );
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged( string propertyName )
    {
        PropertyChanged.Invoke( this, new PropertyChangeEventArguments( propertyName ) );
    }

    public override string ToString()
    {
        return $"Left top x: {_frame.LeftTop.X} Left top y: {_frame.LeftTop.Y} Width: {_frame.Width} Height: {_frame.Height}";
    }
}
