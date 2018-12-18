using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel.Interface;

namespace DrawingModel.Model
{
    public class Line : Shape
    {
        public double x1
        {
            get;
            set;
        }
        public double y1
        {
            get;
            set;
        }
        public double x2
        {
            get;
            set;
        }
        public double y2
        {
            get;
            set;
        }

        //畫線
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(x1, y1, x2, y2);
        }
    }
}
