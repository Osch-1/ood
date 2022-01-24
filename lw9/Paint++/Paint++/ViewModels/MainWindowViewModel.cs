using System.ComponentModel;
using Domain;

namespace Paint__.ViewModels;

internal class MainWindowViewModel : INotifyPropertyChanged
{
    private Document _document;
    private CanvasViewModel _canvasViewModel;

    public Document Document => _document;
    public CanvasViewModel CanvasViewModel
    {
        get
        {
            return _canvasViewModel;
        }

        set
        {
            _canvasViewModel = value;
            OnPropertyChanged( "Canvas" );
        }
    }

    public MainWindowViewModel()
    {
        _document = new Document( new Canvas() );
        _canvasViewModel = new CanvasViewModel( Document, new SelectedShapeViewModel( Document ) );
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged( string propertyName )
    {
        PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }
}
