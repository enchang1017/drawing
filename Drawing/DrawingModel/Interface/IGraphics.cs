using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Interface
{
    public interface IGraphics
    {
        //清除
        void ClearAll();

        //畫線
        void DrawLine(double x1, double y1, double x2, double y2);

        //畫方塊
        void DrawDiamond(double x1, double y1, double x2, double y2);
    }
}
