using System.ComponentModel;
using Domain;

namespace Paint__.ViewModels;

public class ShapeViewModel : INotifyPropertyChanged
{
    private Shape _shape;

    public double LeftTopX
    {
        get
        {
            return _shape.Frame.LeftTop.X;
        }
        set
        {
            _shape.Frame.LeftTop.SetAbscissa( value );
        }
    }

    public double LeftTopY
    {
        get
        {
            return _shape.Frame.LeftTop.Y;
        }
        set
        {
            _shape.Frame.LeftTop.SetOrdinate( value );
        }
    }

    public double Width
    {
        get
        {
            return _shape.Frame.Width;
        }
        set
        {
            _shape.SetWidth( value );
        }
    }

    public double Height
    {
        get
        {
            return _shape.Frame.Height;
        }
        set
        {
            _shape.SetHeight( value );
        }
    }

    public ShapeType ShapeType => _shape.ShapeType;

    public ShapeViewModel( Shape shape )
    {
        _shape = shape ?? throw new System.ArgumentNullException( nameof( shape ) );

        _shape.PropertyChanged += ShapeModelPropertyChanged;
    }

    private void ShapeModelPropertyChanged( object sender, Domain.EventModel.PropertyChangeEventArguments eventArguments )
    {
        OnPropertyChanged( eventArguments.PropertyName );
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged( string propertyName )
    {
        PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }
}