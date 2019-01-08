using DrawingModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Model
{
    class CommandManager
    {
        private Stack<ICommand> _undo = new Stack<ICommand>();
        private Stack<ICommand> _redo = new Stack<ICommand>();

        //執行
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);// push command 進 _undo stack
            _redo.Clear();// 清除_redo stack
        }

        //清除
        public void Clear()
        {
            _undo.Clear();
            _redo.Clear();
        }

        //上一步
        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception(Constant.UNDO_EXCEPTION);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.DoNotExecute();
        }

        //下一步
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception(Constant.REDO_EXCEPTION);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
