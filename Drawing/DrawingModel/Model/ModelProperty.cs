using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Model
{
    public partial class Model
    {
        //上一步
        public void Undo()
        {
            _commandManager.Undo();
        }

        //下一步
        public void Redo()
        {
            _commandManager.Redo();
        }

        //通知畫面更改
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        //狀態(什麼圖形)
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }
    }
}
