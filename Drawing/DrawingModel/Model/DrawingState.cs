using DrawingModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Model
{
    public class DrawingState : IState
    {
        public string StateName
        {
            get
            {
                return Constant.DRAWING_STATE;
            }
        }
    }
}
