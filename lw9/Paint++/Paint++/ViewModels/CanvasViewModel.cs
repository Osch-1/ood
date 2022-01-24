using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Application;
using Domain;
using Paint__.Commands;
using Paint__.Handlers;

namespace Paint__.ViewModels;

internal class CanvasViewModel : INotifyPropertyChanged, ISelectableItemContainerContext
{
    private readonly ShapeFactory _shapeFactory = new();

    private Document _document;
    private ObservableCollection<ShapeViewModel> _shapeViewModels;
    private SelectedShapeViewModel _selectedShapeViewModel;

    public double Width => _document.Canvas.Width;
    public double Height => _document.Canvas.Height;

    public ObservableCollection<ShapeViewModel> ShapeViewModels => _shapeViewModels;
    public SelectedShapeViewModel SelectedShapeViewModel
    {
        get => _selectedShapeViewModel;
        set
        {
            if ( _selectedShapeViewModel != value )
            {
                _selectedShapeViewModel = value;
                OnPropertyChanged( "ShapeSelection" );
            }
        }
    }

    public ICommand AddEllipse => GetAddEllipseCommand();
    public ICommand AddRectangle => GetAddRectangleCommand();
    public ICommand AddTriangle => GetAddTriangleCommand();
    public ICommand DeleteSelectedShape => GetDeleteSelectedShapeCommand();
    public ICommand SelectShape => GetSelectShapeCommand();
    public ICommand RemoveShapeSelection => GetRemoveShapeSelectionCommand();

    public CanvasViewModel( Document document, SelectedShapeViewModel selectedShapeViewModel )
    {
        _document = document ?? throw new ArgumentNullException( nameof( document ) );
        _selectedShapeViewModel = selectedShapeViewModel;
        _shapeViewModels = new();

        document.Canvas.ShapesCollection.CollectionChanged += OnShapeCollectionChanged;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public object GetSelected()
    {
        return SelectedShapeViewModel.Shape;
    }

    public void SelectObject( object obj )
    {
        SelectShape.Execute( obj );
    }

    public void RemoveSelection()
    {
        RemoveShapeSelection.Execute( default );
    }

    private ICommand GetSelectShapeCommand()
    {
        return new RelayCommand( o =>
         {
             _selectedShapeViewModel.Shape = o as ShapeViewModel;
         } );
    }

    private ICommand GetRemoveShapeSelectionCommand()
    {
        return new RelayCommand( o =>
        {
            _selectedShapeViewModel.Shape = null;
        } );
    }

    private void OnShapeCollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
    {
        if ( sender is ObservableCollection<Shape> origin )
        {
            switch ( e.Action )
            {
                case NotifyCollectionChangedAction.Add:
                    _shapeViewModels.Insert( e.NewStartingIndex, new ShapeViewModel( origin[ e.NewStartingIndex ] ) );
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _shapeViewModels.RemoveAt( e.OldStartingIndex );
                    break;
                default:
                    break;
            }
        }
    }

    private ICommand GetAddEllipseCommand()
    {
        return new RelayCommand( o =>
        {
            Shape shape = _shapeFactory.Create( ShapeType.Ellipse );
            _document.Canvas.AddShape( shape );
        } );
    }

    private ICommand GetAddRectangleCommand()
    {
        return new RelayCommand( o =>
        {
            Shape shape = _shapeFactory.Create( ShapeType.Rectangle );
            _document.Canvas.AddShape( shape );
        } );
    }

    private ICommand GetAddTriangleCommand()
    {
        return new RelayCommand( o =>
        {
            Shape shape = _shapeFactory.Create( ShapeType.Triangle );
            _document.Canvas.AddShape( shape );
        } );
    }

    private ICommand GetDeleteSelectedShapeCommand()
    {
        return new RelayCommand( o =>
        {
            if ( SelectedShapeViewModel?.Shape != null )
            {
                int index = _shapeViewModels.IndexOf( SelectedShapeViewModel.Shape );
                if ( index >= 0 )
                {
                    _document.Canvas.RemoveShape( index );
                }
            }
        } );
    }

    private void OnPropertyChanged( string v )
    {
        PropertyChanged.Invoke( this, new PropertyChangedEventArgs( v ) );
    }
}
