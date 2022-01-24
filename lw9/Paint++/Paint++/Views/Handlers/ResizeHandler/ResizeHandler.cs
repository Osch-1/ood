using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Paint__.Views.Handlers;

public class ResizeHandler
{
    private static readonly Lazy<ResizeHandler> _instance = new( () => new ResizeHandler() );

    private static ResizeHandler Instance => _instance.Value;

    private const double _minSizeValue = 5;

    private bool _isMouseHolded;
    private Point _delta;
    private Size _previousSize;
    private Point _previousPosition;
    private Point _initialMousePosition;
    private DependencyObject _context;
    private FrameworkElement _moveContainer;
    private FrameworkElement _selectionContainer;
    private FrameworkElement _bottomRightResizeMarker;
    private FrameworkElement _bottomLeftResizeMarker;
    private FrameworkElement _topLeftResizeMarker;
    private FrameworkElement _topRightResizeMarker;

    private void Init( object sender, DependencyPropertyChangedEventArgs e )
    {
        SetupInstance( sender );
        RegisterMarkersEventHandlers();
    }

    private void SetupInstance( object sender )
    {
        Instance._bottomLeftResizeMarker = GetBottomLeftResizeMarker( sender as DependencyObject );
        Instance._bottomRightResizeMarker = GetBottomRightResizeMarker( sender as DependencyObject );
        Instance._topLeftResizeMarker = GetTopLeftResizeMarker( sender as DependencyObject );
        Instance._topRightResizeMarker = GetTopRightResizeMarker( sender as DependencyObject );
    }

    private void RegisterMarkersEventHandlers()
    {
        AddEventHandlers( Instance._bottomRightResizeMarker );
        AddEventHandlers( Instance._bottomLeftResizeMarker );
        AddEventHandlers( Instance._topLeftResizeMarker );
        AddEventHandlers( Instance._topRightResizeMarker );
    }

    private void AddEventHandlers( FrameworkElement element )
    {
        if ( element is not null )
        {
            element.PreviewMouseLeftButtonDown += StartWatch;
            element.MouseLeftButtonUp += StopWatch;
        }
    }

    private static void IsResizeSourceChanged( DependencyObject source, DependencyPropertyChangedEventArgs eventArgs )
    {
        if ( source is not UIElement resizeSource )
        {
            return;
        }

        if ( eventArgs.NewValue is true )
        {
            resizeSource.IsVisibleChanged += Instance.Init;
            Instance._context = resizeSource;
        }
    }

    private void StartWatch( object sender, MouseButtonEventArgs eventArgs )
    {
        if ( sender is not DependencyObject element )
        {
            return;
        }

        _selectionContainer = GetSelectionContainer( _context );
        _moveContainer = GetMoveContainer( _context );
        _initialMousePosition = eventArgs.GetPosition( _moveContainer );

        _previousPosition = new( Canvas.GetLeft( _selectionContainer ), Canvas.GetTop( _selectionContainer ) );
        _previousSize.Width = _selectionContainer.Width;
        _previousSize.Height = _selectionContainer.Height;

        if ( _moveContainer is null )
        {
            return;
        }

        RemoveMoveContainerMarkerHandlers();

        if ( sender == _bottomRightResizeMarker )
        {
            _moveContainer.PreviewMouseMove += BottomRightResizeMarkerHandler;
            _bottomRightResizeMarker.PreviewMouseMove += BottomRightResizeMarkerHandler;
        }
        else if ( sender == _bottomLeftResizeMarker )
        {
            _moveContainer.PreviewMouseMove += BottomLeftResizeMarkerHandler;
            _bottomLeftResizeMarker.PreviewMouseMove += BottomLeftResizeMarkerHandler;
        }
        else if ( sender == _topLeftResizeMarker )
        {
            _moveContainer.PreviewMouseMove += TopLeftResizeMarkerHandler;
            _topLeftResizeMarker.PreviewMouseMove += TopLeftResizeMarkerHandler;
        }
        else if ( sender == _topRightResizeMarker )
        {
            _moveContainer.PreviewMouseMove += TopRightResizeMarkerHandler;
            _topRightResizeMarker.PreviewMouseMove += TopRightResizeMarkerHandler;
        }

        _moveContainer.MouseLeftButtonUp += StopWatch;

        _isMouseHolded = true;
    }

    private void StopWatch( object sender, MouseButtonEventArgs eventArgs )
    {
        if ( _moveContainer is null || !_isMouseHolded )
        {
            return;
        }

        _isMouseHolded = false;
        RemoveMoveContainerMarkerHandlers();
        RemoveMarkerHandlers();

        _moveContainer.MouseLeftButtonUp -= StopWatch;
    }

    private void RemoveMarkerHandlers()
    {
        _bottomRightResizeMarker.PreviewMouseMove -= BottomRightResizeMarkerHandler;
        _bottomLeftResizeMarker.PreviewMouseMove -= BottomLeftResizeMarkerHandler;
        _topLeftResizeMarker.PreviewMouseMove -= TopLeftResizeMarkerHandler;
        _topRightResizeMarker.PreviewMouseMove -= TopRightResizeMarkerHandler;
    }

    private void RemoveMoveContainerMarkerHandlers()
    {
        _moveContainer.PreviewMouseMove -= BottomRightResizeMarkerHandler;
        _moveContainer.PreviewMouseMove -= BottomLeftResizeMarkerHandler;
        _moveContainer.PreviewMouseMove -= TopLeftResizeMarkerHandler;
        _moveContainer.PreviewMouseMove -= TopRightResizeMarkerHandler;
    }

    private void TopLeftResizeMarkerHandler( object sender, MouseEventArgs eventArgs )
    {
        if ( !_isMouseHolded )
        {
            return;
        }

        Point currentPoint = eventArgs.GetPosition( _moveContainer );
        _delta.X = currentPoint.X - _initialMousePosition.X;
        _delta.Y = currentPoint.Y - _initialMousePosition.Y;

        _selectionContainer.Width = MinSizeIfValueIsLess( _previousSize.Width - _delta.X );
        _selectionContainer.Height = MinSizeIfValueIsLess( _previousSize.Height - _delta.Y );

        if ( IsValidResize( _previousSize.Height - _delta.Y ) )
        {
            Canvas.SetTop( _selectionContainer, _previousPosition.Y + _delta.Y );
        }

        if ( IsValidResize( _previousSize.Height - _delta.X ) )
        {
            Canvas.SetLeft( _selectionContainer, _previousPosition.X + _delta.X );
        }
    }

    private void TopRightResizeMarkerHandler( object sender, MouseEventArgs eventArgs )
    {
        if ( !_isMouseHolded )
        {
            return;
        }

        Point currentPoint = eventArgs.GetPosition( _moveContainer );
        _delta.X = currentPoint.X - _initialMousePosition.X;
        _delta.Y = currentPoint.Y - _initialMousePosition.Y;

        _selectionContainer.Width = MinSizeIfValueIsLess( _previousSize.Width + _delta.X );
        _selectionContainer.Height = MinSizeIfValueIsLess( _previousSize.Height - _delta.Y );

        if ( IsValidResize( _previousSize.Height - _delta.Y ) )
        {
            Canvas.SetTop( _selectionContainer, _previousPosition.Y + _delta.Y );
        }
    }

    private void BottomRightResizeMarkerHandler( object sender, MouseEventArgs eventArgs )
    {
        if ( !_isMouseHolded )
            return;

        Point currentPoint = eventArgs.GetPosition( _moveContainer );
        _delta.X = currentPoint.X - _initialMousePosition.X;
        _delta.Y = currentPoint.Y - _initialMousePosition.Y;

        _selectionContainer.Width = MinSizeIfValueIsLess( _previousSize.Width + _delta.X );
        _selectionContainer.Height = MinSizeIfValueIsLess( _previousSize.Height + _delta.Y );
    }

    private void BottomLeftResizeMarkerHandler( object sender, MouseEventArgs eventArgs )
    {
        if ( !_isMouseHolded )
        {
            return;
        }

        Point currentPoint = eventArgs.GetPosition( _moveContainer );
        _delta.X = currentPoint.X - _initialMousePosition.X;
        _delta.Y = currentPoint.Y - _initialMousePosition.Y;

        _selectionContainer.Width = MinSizeIfValueIsLess( _previousSize.Width - _delta.X );
        _selectionContainer.Height = MinSizeIfValueIsLess( _previousSize.Height + _delta.Y );
        if ( IsValidResize( _previousSize.Width - _delta.X ) )
        {
            Canvas.SetLeft( _selectionContainer, _previousPosition.X + _delta.X );
        }
    }

    private static double MinSizeIfValueIsLess( double value )
    {
        if ( IsValidResize( value ) )
        {
            return value;
        }

        return _minSizeValue;
    }

    private static bool IsValidResize( double size )
    {
        return size > _minSizeValue;
    }

    public static readonly DependencyProperty IsResizeFrameProperty = DependencyProperty.RegisterAttached(
        "IsResizeFrame", typeof( bool ), typeof( ResizeHandler ), new PropertyMetadata( false, IsResizeSourceChanged ) );

    public static readonly DependencyProperty MoveContainerProperty = DependencyProperty.RegisterAttached(
        "MoveContainer", typeof( FrameworkElement ), typeof( ResizeHandler ), new PropertyMetadata() );

    public static readonly DependencyProperty FrameContainerProperty = DependencyProperty.RegisterAttached(
        "FrameContainer", typeof( FrameworkElement ), typeof( ResizeHandler ), new PropertyMetadata() );

    public static readonly DependencyProperty BottomRightResizeMarkerProperty = DependencyProperty.RegisterAttached(
        "BottomRightResizeMarker", typeof( FrameworkElement ), typeof( ResizeHandler ), new PropertyMetadata() );

    public static readonly DependencyProperty BottomLeftResizeMarkerProperty = DependencyProperty.RegisterAttached(
        "BottomLeftResizeMarker", typeof( FrameworkElement ), typeof( ResizeHandler ), new PropertyMetadata() );

    public static readonly DependencyProperty TopLeftResizeMarkerProperty = DependencyProperty.RegisterAttached(
        "TopLeftResizeMarker", typeof( FrameworkElement ), typeof( ResizeHandler ), new PropertyMetadata() );

    public static readonly DependencyProperty TopRightResizeMarkerProperty = DependencyProperty.RegisterAttached(
        "TopRightResizeMarker", typeof( FrameworkElement ), typeof( ResizeHandler ), new PropertyMetadata() );

    public static bool GetIsResizeFrame( DependencyObject element )
    {
        return ( bool )element.GetValue( IsResizeFrameProperty );
    }

    public static void SetIsResizeFrame( DependencyObject element, bool value )
    {
        element.SetValue( IsResizeFrameProperty, value );
    }

    public static FrameworkElement GetMoveContainer( DependencyObject element )
    {
        return ( FrameworkElement )element.GetValue( MoveContainerProperty );
    }

    public static void SetMoveContainer( DependencyObject element, FrameworkElement value )
    {
        element.SetValue( MoveContainerProperty, value );
    }

    public static FrameworkElement GetSelectionContainer( DependencyObject element )
    {
        return ( FrameworkElement )element.GetValue( FrameContainerProperty );
    }

    public static void SetFrameContainer( DependencyObject element, Canvas value )
    {
        element.SetValue( FrameContainerProperty, value );
    }

    public static FrameworkElement GetBottomRightResizeMarker( DependencyObject element )
    {
        return ( FrameworkElement )element.GetValue( BottomRightResizeMarkerProperty );
    }

    public static void SetBottomRightResizeMarker( DependencyObject element, FrameworkElement value )
    {
        element.SetValue( BottomRightResizeMarkerProperty, value );
    }

    public static FrameworkElement GetBottomLeftResizeMarker( DependencyObject element )
    {
        return ( FrameworkElement )element.GetValue( BottomLeftResizeMarkerProperty );
    }

    public static void SetBottomLeftResizeMarker( DependencyObject element, FrameworkElement value )
    {
        element.SetValue( BottomLeftResizeMarkerProperty, value );
    }

    public static FrameworkElement GetTopLeftResizeMarker( DependencyObject element )
    {
        return ( FrameworkElement )element.GetValue( TopLeftResizeMarkerProperty );
    }

    public static void SetTopLeftResizeMarker( DependencyObject element, FrameworkElement value )
    {
        element.SetValue( TopLeftResizeMarkerProperty, value );
    }

    public static FrameworkElement GetTopRightResizeMarker( DependencyObject element )
    {
        return ( FrameworkElement )element.GetValue( TopRightResizeMarkerProperty );
    }

    public static void SetTopRightResizeMarker( DependencyObject element, FrameworkElement value )
    {
        element.SetValue( TopRightResizeMarkerProperty, value );
    }
}