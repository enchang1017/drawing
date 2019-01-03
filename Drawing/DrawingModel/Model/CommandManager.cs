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

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            _undo.Push(cmd);    // push command 進 _undo stack
            _redo.Clear();      // 清除_redo stack
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
                throw new Exception("Cannot Undo exception\n");
            ICommand cmd = _undo.Pop();
            _redo.Push(cmd);
            cmd.UnExecute();
        }

        //下一步
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception("Cannot Redo exception\n");
            ICommand cmd = _redo.Pop();
            _undo.Push(cmd);
            cmd.Execute();
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
