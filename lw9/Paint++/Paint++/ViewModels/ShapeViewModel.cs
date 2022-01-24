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
            return _shape.LeftTopX;
        }
        set
        {
            _shape.LeftTopX = value;
        }
    }

    public double LeftTopY
    {
        get
        {
            return _shape.LeftTopY;
        }
        set
        {
            _shape.LeftTopY = value;
        }
    }

    public double Width
    {
        get
        {
            return _shape.Width;
        }
        set
        {
            _shape.Width = value;
        }
    }

    public double Height
    {
        get
        {
            return _shape.Height;
        }
        set
        {
            _shape.Height = value;
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