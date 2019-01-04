using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Interface
{
    public interface Shape
    {
        double x1
        {
            get;
            set;
        }

        double x2
        {
            get;
            set;
        }

        double y1
        {
            get;
            set;
        }

        double y2
        {
            get;
            set;
        }

        //畫線
        void Draw(IGraphics graphics);
    }
}
