using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Domain;

namespace Paint__.ViewModels;

public class SelectedShapeViewModel : INotifyPropertyChanged
{
    private Document _document;
    private ShapeViewModel _shape;

    public ShapeViewModel Shape
    {
        get => _shape;
        set
        {
            if ( _shape != value )
            {
                _shape = value;
                OnPropertyChange( nameof( Shape ) );
            }
        }
    }

    public SelectedShapeViewModel( Document document )
    {
        _document = document;
        _document.Canvas.ShapesCollection.CollectionChanged += OnShapeCollectionChanged;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChange( string propertyName )
    {
        PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }

    private void OnShapeCollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
    {
        if ( sender is ObservableCollection<Shape> origin )
        {
            switch ( e.Action )
            {
                case NotifyCollectionChangedAction.Remove:
                    Shape = null;
                    break;

            }
        }
    }
}
