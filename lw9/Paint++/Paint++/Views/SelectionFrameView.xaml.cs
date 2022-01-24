using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint__.Views;
/// <summary>
/// Interaction logic for SelectionFrameView.xaml
/// </summary>
public partial class SelectionFrameView : UserControl
{
    public SelectionFrameView()
    {
        InitializeComponent();
    }

    public FrameworkElement BindPanel
    {
        get => ( FrameworkElement )GetValue( BindPanelProperty );
        set => SetValue( BindPanelProperty, value );
    }

    public static DependencyProperty BindPanelProperty = DependencyProperty.RegisterAttached( "BindPanel", typeof( FrameworkElement ), typeof( SelectionFrameView ) );
}
