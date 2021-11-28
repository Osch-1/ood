using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw7
{
    public interface ICanvas
    {
        public void DrawLine( Point from, Point to );
        public void DrawEllipse( Point leftTop, double width, double height );
        public void FillEllipse( Point leftTop, double width, double height );
        public void FillRectangle();
        public void SetFillColor();
    }
}
