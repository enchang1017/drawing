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
        string IState.StateName
        {
            get
            {
                return "DrawingState";
            }
        }
    }
}
