using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Paint__.Handlers;

public class DragAndDropHandler
{
    private static readonly Lazy<DragAndDropHandler> _instance = new( () => new DragAndDropHandler() );

    private static DragAndDropHandler Instance
    {
        get => _instance.Value;
    }

    private bool _isMouseHolded;
    private Point _initialMousePosition;
    private Point _previousPosition;
    private Point _delta;
    private FrameworkElement _moveContainer;
    private FrameworkElement _context;

    private void StartWatching( object sender, MouseButtonEventArgs eventArgs )
    {
        _context = sender as FrameworkElement;

        if ( sender is not DependencyObject senderOrigin )
        {
            return;
        }

        _moveContainer = GetMoveContainer( senderOrigin );
        _initialMousePosition = eventArgs.GetPosition( _moveContainer );
        _isMouseHolded = true;

        InitiEventHandlers();
        CapturePosition( sender as UIElement );

    }

    private void InitiEventHandlers()
    {
        _moveContainer.PreviewMouseMove += MouseMoveHandler;
        _context.PreviewMouseMove += MouseMoveHandler;        
    }

    private void ReleaseShape( object sender, MouseButtonEventArgs eventArgs )
    {
        if ( !_isMouseHolded )
        {
            return;
        }

        _isMouseHolded = false;
        RemoveEventHandlers();
    }

    private void RemoveEventHandlers()
    {
        _context.PreviewMouseMove -= MouseMoveHandler;
        _moveContainer.PreviewMouseMove -= MouseMoveHandler;
    }

    private void CapturePosition( UIElement uIElement )
    {
        _previousPosition = new Point( Canvas.GetLeft( uIElement ), Canvas.GetTop( uIElement ) );
    }

    private void MouseMoveHandler( object sender, MouseEventArgs eventArgs )
    {
        if ( !_isMouseHolded )
        {
            return;
        }

        Point currentPoint = eventArgs.GetPosition( _moveContainer );
        _delta.X = currentPoint.X - _initialMousePosition.X;
        _delta.Y = currentPoint.Y - _initialMousePosition.Y;

        Canvas.SetLeft( _context, _previousPosition.X + _delta.X );
        Canvas.SetTop( _context, _previousPosition.Y + _delta.Y );
    }

    public static readonly DependencyProperty MoveContainerProperty = DependencyProperty.RegisterAttached(
        "MoveContainer", typeof( FrameworkElement ), typeof( DragAndDropHandler ), new PropertyMetadata() );

    public static readonly DependencyProperty IsDraggableProperty = DependencyProperty.RegisterAttached(
        "IsDraggable", typeof( bool ), typeof( DragAndDropHandler ), new PropertyMetadata( false, IsDragContextChanged ) );

    public static FrameworkElement GetMoveContainer( DependencyObject element )
    {
        return ( FrameworkElement )element.GetValue( MoveContainerProperty );
    }

    public static void SetMoveContainer( DependencyObject element, FrameworkElement value )
    {
        element.SetValue( MoveContainerProperty, value );
    }

    public static bool GetIsDraggable( DependencyObject element )
    {
        return ( bool )element.GetValue( IsDraggableProperty );
    }

    public static void SetIsDraggable( DependencyObject element, bool value )
    {
        element.SetValue( IsDraggableProperty, value );
    }

    private static void IsDragContextChanged( DependencyObject element, DependencyPropertyChangedEventArgs eventArgs )
    {
        if ( element is not UIElement dragSource )
        {
            return;
        }

        if ( eventArgs.NewValue is true )
        {
            dragSource.PreviewMouseLeftButtonDown += Instance.StartWatching;
            dragSource.PreviewMouseLeftButtonUp += Instance.ReleaseShape;
        }
    }
}
