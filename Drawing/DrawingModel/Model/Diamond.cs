using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel.Interface;

namespace DrawingModel.Model
{
    public class Diamond : Shape
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

        //判斷是否在圖形內
        public bool DetectInRange(double pointX, double pointY)
        {
            double width = Math.Abs(this.x1 - this.x2);
            double height = Math.Abs(this.y1 - this.y2);
            double secondPointX = Math.Abs(pointX - (this.x1 + this.x2) / Constant.DIVISOR_HALF);
            double secondPointY = Math.Abs(pointY - (this.y1 + this.y2) / Constant.DIVISOR_HALF);
            bool result = (secondPointX * height + secondPointY * width) <= width * height;

            return result;
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.DrawDiamond(x1, y1, x2, y2);
        }
    }
}
