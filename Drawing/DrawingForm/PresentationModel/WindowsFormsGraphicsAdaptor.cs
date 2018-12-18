using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel.Interface;
using DrawingModel.Model;

namespace DrawingForm
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //清除
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫方塊
        public void DrawDiamond(double x1, double y1, double x2, double y2)
        {
            int middleOfX = (int)(x1 + (x2 - x1) / Constant.DIVISOR);
            int middleOfY = (int)(y1 + (y2 - y1) / Constant.DIVISOR);
            Point[] points = { new Point(middleOfX, (int)y1), new Point((int)x1, middleOfY), new Point(middleOfX, (int)y2), new Point((int)x2, middleOfY) };
            _graphics.FillPolygon(Brushes.Yellow, points);
            _graphics.DrawPolygon(Pens.Black, points);
        }
    }
}
