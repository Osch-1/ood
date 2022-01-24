using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Paint__.Handlers.ResizeHandler;

public class ResizeHandler
{
    private static readonly SelectionHandler _instance = new();

    public static readonly DependencyProperty TopLeftResizeMarker;
}
