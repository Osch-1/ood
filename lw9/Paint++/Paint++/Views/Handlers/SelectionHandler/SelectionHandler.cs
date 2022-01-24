using System.Windows;
using System.Windows.Input;

namespace Paint__.Handlers;

public class SelectionHandler
{
    private ISelectableItemContainerContext _selectableItemContainerContext;

    private static readonly SelectionHandler _instance = new();

    public static bool GetIsSelectable( DependencyObject element )
    {
        return ( bool )element.GetValue( IsSelectableProperty );
    }

    public static void SetIsDeselectField( DependencyObject element, bool value )
    {
        element.SetValue( IsDeselectFieldProperty, value );
    }

    public static ISelectableItemContainerContext GetSelectContext( DependencyObject element )
    {
        return ( ISelectableItemContainerContext )element.GetValue( SelectContextProperty );
    }

    public static void SetSelectContext( DependencyObject element, ISelectableItemContainerContext value )
    {
        element.SetValue( SelectContextProperty, value );
    }

    public static void SetIsSelectable( DependencyObject element, bool value )
    {
        element.SetValue( IsSelectableProperty, value );
    }

    private static void OnSelectionSourceChanged( DependencyObject element, DependencyPropertyChangedEventArgs e )
    {
        UIElement selectSource = element as UIElement;

        if ( e.NewValue is true )
        {
            selectSource.PreviewMouseLeftButtonDown += _instance.Select;
        }
    }

    private void Select( object sender, MouseButtonEventArgs e )
    {
        if ( _selectableItemContainerContext is null )
        {
            _selectableItemContainerContext = GetSelectContext( ( DependencyObject )sender );
        }

        if ( _selectableItemContainerContext is not null )
        {
            _selectableItemContainerContext.SelectObject( ( sender as FrameworkElement ).DataContext );
        }
    }

    public static bool GetIsDeselectField( DependencyObject element )
    {
        return ( bool )element.GetValue( IsDeselectFieldProperty );
    }

    private static void OnDeselectionPropertyChanged( DependencyObject element, DependencyPropertyChangedEventArgs e )
    {
        if ( element is UIElement deselectSource )
        {
            deselectSource.PreviewMouseLeftButtonDown += _instance.Deselect;
        }
    }

    private void Deselect( object sender, MouseButtonEventArgs e )
    {
        if ( _selectableItemContainerContext is null )
        {
            _selectableItemContainerContext = GetSelectContext( ( DependencyObject )sender );
        }

        if ( _selectableItemContainerContext is not null )
        {
            _selectableItemContainerContext.RemoveSelection();
        }
    }

    public static readonly DependencyProperty IsSelectableProperty = DependencyProperty.RegisterAttached(
        "IsSelectable", typeof( bool ), typeof( SelectionHandler ), new PropertyMetadata( false, OnSelectionSourceChanged ) );

    public static readonly DependencyProperty IsDeselectFieldProperty = DependencyProperty.RegisterAttached(
        "IsDeselectField", typeof( bool ), typeof( SelectionHandler ), new PropertyMetadata( false, OnDeselectionPropertyChanged ) );

    public static readonly DependencyProperty SelectContextProperty = DependencyProperty.RegisterAttached(
        "SelectContext", typeof( ISelectableItemContainerContext ), typeof( SelectionHandler ), new PropertyMetadata() );
}
