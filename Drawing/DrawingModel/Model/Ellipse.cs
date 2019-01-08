using DrawingModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Model
{
    public class Ellipse : Shape
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
            var width = this.x1 - this.x2;
            var height = this.y1 - this.y2;
            bool result = false;
            double xRadius = width / Constant.DIVISOR_HALF;
            double yRadius = height / Constant.DIVISOR_HALF;
            double centerX = this.x2 + xRadius;
            double centerY = this.y2 + yRadius;
            double normalPointX = pointX - centerX;
            double normalPointY = pointY - centerY;
            double distance = ((double)(normalPointX * normalPointX) / (xRadius * xRadius)) +
            ((double)(normalPointY * normalPointY) / (yRadius * yRadius));
            result = distance <= Constant.MIN_DISTANCE; //MIN_DISTANCE decides how is sensitive

            return result;
        }

        //畫線
        public void Draw(IGraphics graphics)
        {
            graphics.DrawEllipses(x1, y1, x2, y2);
        }
    }
}
