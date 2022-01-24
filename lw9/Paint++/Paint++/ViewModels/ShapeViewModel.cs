using System.ComponentModel;
using Domain;

namespace Paint__.ViewModels;

internal class ShapeViewModel : INotifyPropertyChanged
{
    private Shape _shape;

    public ShapeType ShapeType => _shape.ShapeType;
    public double Width => _shape.Frame.Width;
    public double Height => _shape.Frame.Height;

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