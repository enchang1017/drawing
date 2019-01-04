using DrawingModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Model
{
    public class ShapeFactory
    {
        //創造Shape
        public Shape CreateShape(string shapeName)
        {
            if (shapeName == Constant.LINE)
                return new Line();
            else if (shapeName == Constant.DIAMOND)
                return new Diamond();
            else if (shapeName == Constant.ELLIPSE)
                return new Ellipse();
            else
                return null;
        }
    }
}
