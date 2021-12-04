using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw7.Styles
{
    public class FillStyle : IFillStyle
    {
        public bool IsEnabled => throw new NotImplementedException();

        public IRGBAColor Color
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public bool Equals( IFillStyle other )
        {
            throw new NotImplementedException();
        }
    }
}
