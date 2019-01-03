using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Interface
{
    interface ICommand
    {
        //執行Redo
        void Execute();
        //執行Undo
        void UnExecute();
    }
}
