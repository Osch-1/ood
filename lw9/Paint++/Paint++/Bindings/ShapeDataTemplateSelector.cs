using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Paint__.ViewModels;

namespace Paint__.Bindings;

public class ShapeDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate Ellipse { get; set; }
    public DataTemplate Rectangle { get; set; }
    public DataTemplate Triangle { get; set; }

    public override DataTemplate? SelectTemplate( object item, DependencyObject container )
    {
        if ( item is ShapeViewModel shapeViewModel )
        {
            switch ( shapeViewModel.ShapeType )
            {
                case Domain.ShapeType.Ellipse:
                    return Ellipse;
                case Domain.ShapeType.Rectangle:
                    return Rectangle;
                case Domain.ShapeType.Triangle:
                    return Triangle;
            }
        }

        throw new Exception();
    }
}
