using DrawingModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Model
{
    public partial class Model
    {
        //將點回復
        public void MinusPoint(Shape shape, double pointX, double pointY, double firstPointX, double firstPointY)
        {
            shape.x1 += (firstPointX - pointX);
            shape.x2 += (firstPointX - pointX);
            shape.y1 += (firstPointY - pointY);
            shape.y2 += (firstPointY - pointY);
        }

        //改變狀態
        public void ChangeState(string StateName)
        {
            if (StateName == nameof(PointerState))
            {
                this.State = new PointerState();
            }
            else if (StateName == nameof(DrawingState))
            {
                this.State = new DrawingState();
            }
        }

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

        public IState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }
    }
}
