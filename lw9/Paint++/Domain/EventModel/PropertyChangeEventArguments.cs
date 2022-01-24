namespace Domain.EventModel;

public class PropertyChangeEventArguments : EventArgs
{
    private string _propertyName;

    public string PropertyName => _propertyName;

    public PropertyChangeEventArguments( string propertyName )
    {
        _propertyName = propertyName;
    }
}