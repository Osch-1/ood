using System;
using System.Windows;
using System.Windows.Input;

namespace Paint__.Handlers;

public class SelectionHandler
{
    private ISelectableItemContainerContext _selectableItemContainerContext;

    private static readonly SelectionHandler _instance = new();

    public static readonly DependencyProperty IsSelectable = DependencyProperty.RegisterAttached(
        "IsSelectable", typeof( bool ), typeof( SelectionHandler ), new PropertyMetadata( false, IsSelectSourceChanged ) );


    public static readonly DependencyProperty SelectionContext = DependencyProperty.RegisterAttached(
        "SelectContext", typeof( ISelectableItemContainerContext ), typeof( SelectionHandler ), new PropertyMetadata() );

    public static bool GetIsSelectable( DependencyObject element )
    {
        return ( bool )element.GetValue( IsSelectable );
    }

    public static void SetIsSelectable( DependencyObject element, Boolean value )
    {
        element.SetValue( IsSelectable, value );
    }

    private static void IsSelectSourceChanged( DependencyObject element, DependencyPropertyChangedEventArgs e )
    {
        UIElement selectSource = element as UIElement;

        if ( e.NewValue is true )
        {
            selectSource.PreviewMouseLeftButtonDown += _instance.Select;
        }
        else
        {
            selectSource.PreviewMouseLeftButtonDown -= _instance.Select;
        }
    }

    public static ISelectableItemContainerContext GetSelectContext( DependencyObject element )
    {
        return ( ISelectableItemContainerContext )element.GetValue( SelectionContext );
    }

    public static void SetSelectContext( DependencyObject element, ISelectableItemContainerContext value )
    {
        element.SetValue( SelectionContext, value );
    }

    public static readonly DependencyProperty IsDeselectField = DependencyProperty.RegisterAttached(
        "IsDeselectField", typeof( bool ), typeof( SelectionHandler ), new PropertyMetadata( false, OnIsDeselectPropertyChanged ) );

    public static bool GetIsDeselectField( DependencyObject element )
    {
        return ( bool )element.GetValue( IsDeselectField );
    }

    public static void SetIsDeselectField( DependencyObject element, bool value )
    {
        element.SetValue( IsDeselectField, value );
    }

    private static void OnIsDeselectPropertyChanged( DependencyObject element, DependencyPropertyChangedEventArgs e )
    {
        if ( element is UIElement deselectSource )
        {
            deselectSource.PreviewMouseLeftButtonDown += _instance.Deselect;
        }
    }

    private void Select( object sender, MouseButtonEventArgs e )
    {
        if ( _selectableItemContainerContext is null )
        {
            _selectableItemContainerContext = GetSelectContext( ( DependencyObject )sender );
        }

        _selectableItemContainerContext.SelectObject( ( sender as FrameworkElement ).DataContext );
    }

    private void Deselect( object sender, MouseButtonEventArgs e )
    {
        if ( _selectableItemContainerContext == null )
        {
            _selectableItemContainerContext = GetSelectContext( ( DependencyObject )sender );
        }

        _selectableItemContainerContext.RemoveSelection();
    }
}
