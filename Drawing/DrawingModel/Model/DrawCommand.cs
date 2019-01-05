using DrawingModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Model
{
    class DrawCommand : ICommand
    {
        private Shape _shape;
        private Model _model;
        public DrawCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        //執行儲存Shape List
        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        //刪除Shape
        public void UnExecute()
        {
            _model.DeleteShape();
        }
    }
}
