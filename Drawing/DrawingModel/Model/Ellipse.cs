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
            var width = Math.Abs(this.x1 - this.x2);
            var height = Math.Abs(this.y1 - this.y2);
            bool result = false;
            double xRadius = width / 2;
            double yRadius = height / 2;
            double centerX = this.x1 + xRadius;
            double centerY = this.x2 + yRadius;
            double normalizedX = pointX - centerX;
            double normalizedY = pointY - centerY;
            double distance = ((double)(normalizedX * normalizedX) / (xRadius * xRadius)) +
            ((double)(normalizedY * normalizedY) / (yRadius * yRadius));
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
