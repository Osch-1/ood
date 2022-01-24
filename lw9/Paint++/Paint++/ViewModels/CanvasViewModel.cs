using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application;
using Domain;
using Paint__.Commands;

namespace Paint__.ViewModels;

internal class CanvasViewModel : INotifyPropertyChanged
{
    private readonly ShapeFactory _shapeFactory = new();

    private Document _document;
    private ObservableCollection<ShapeViewModel> _shapeViewModels;

    public double Width => _document.Canvas.Width;
    public double Height => _document.Canvas.Height;

    public ObservableCollection<ShapeViewModel> ShapeViewModels => _shapeViewModels;

    public ICommand AddEllipse => GetAddEllipseCommand();
    public ICommand AddRectangle => GetAddRectangleCommand();
    public ICommand AddTriangle => GetAddTriangleCommand();

    public CanvasViewModel( Document document )
    {
        _document = document ?? throw new ArgumentNullException( nameof( document ) );
        _shapeViewModels = new();

        document.Canvas.ShapesCollection.CollectionChanged += OnShapeCollectionChanged;
    }

    public event PropertyChangedEventHandler PropertyChanged;

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
                    _shapeViewModels.RemoveAt( e.NewStartingIndex );
                    break;
                default:
                    //log or throw
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
}
