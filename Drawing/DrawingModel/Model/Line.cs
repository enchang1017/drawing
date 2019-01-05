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

        //偵測是否在範圍內
        public bool DetectInRange(double pointX, double pointY)
        {
            double x2MinusX1 = this.x2 - this.x1;
            double y2Minusy1 = this.y2 - this.y1;
            double upper = Math.Abs(x2MinusX1 * (this.y1 - pointY) - (this.x1 - pointX) * y2Minusy1);
            double lower = Math.Sqrt(x2MinusX1 * x2MinusX1 + y2Minusy1 * y2Minusy1);
            bool result = (upper / lower) < Constant.MIN_DISTANCE; //MIN_DISTANCE decides how is sensitive.

            return result;
        }

        //畫線
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(x1, y1, x2, y2);
        }
    }
}
