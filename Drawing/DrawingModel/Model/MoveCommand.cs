using DrawingModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Model
{
    public class MoveCommand : ICommand
    {
        private Shape _shape;
        private Model _model;
        private double _pointX;
        private double _pointY;
        private double _firstPressX;
        private double _firstPressY;

        public MoveCommand(Model model, Shape shape, double pointX, double pointY, double pressPointX, double pressPointY)
        {
            _model = model;
            _shape = shape;
            _pointX = pointX;
            _pointY = pointY;
            _firstPressX = pressPointX;
            _firstPressY = pressPointY;
        }

        //執行
        public void Execute()
        {
            _model.MoveShapePoint(_shape, _pointX, _pointY, _firstPressX, _firstPressY);
        }

        //取消
        public void DoNotExecute()
        {
            _model.SubtractPoint(_shape, _pointX, _pointY, _firstPressX, _firstPressY);
        }
    }
}
