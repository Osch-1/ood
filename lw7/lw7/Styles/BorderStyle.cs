using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw7.Styles
{
    public class BorderStyle : IBorderStyle
    {
        public double BorderHeight
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

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

        public bool Equals( IBorderStyle other )
        {
            throw new NotImplementedException();
        }
    }
}
