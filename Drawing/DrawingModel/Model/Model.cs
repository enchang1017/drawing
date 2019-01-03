using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel.Interface;

namespace DrawingModel.Model
{
    public partial class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private CommandManager _commandManager = new CommandManager();
        private bool _isMousePress = false;
        private List<Shape> _shapes = new List<Shape>();
        private Line _hintLine;
        private Diamond _hintDiamond;
        private Points _point = new Points();
        private string _status;

        //滑鼠點下
        public void PressPointer(double x1, double y1)
        {
            _hintLine = new Line();
            _hintDiamond = new Diamond();
            if (x1 > 0 && y1 > 0)
            {
                _point.FirstPoint_X = x1;
                _point.FirstPoint_Y = y1;
                SetHintPointFirst(_point.FirstPoint_X, _point.FirstPoint_Y);
                _isMousePress = true;
            }
        }

        //滑鼠移動
        public void MovePointer(double x2, double y2)
        {
            if (_isMousePress)
            {
                SetHintPointLast(x2, y2);
                NotifyModelChanged();
            }
        }

        //滑鼠釋放
        public void ReleasePointer(double x2, double y2)
        {
            if (_isMousePress)
            {
                _isMousePress = false;
                SetFinalPoint(x2, y2);
                NotifyModelChanged();
            }
        }

        //清除
        public void Clear()
        {
            _isMousePress = false;
            _shapes.Clear();
            _commandManager.Clear();
            NotifyModelChanged();
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
            if (_isMousePress)
            {
                if (this.Status == Constant.LINE)
                    _hintLine.Draw(graphics);
                else if (this.Status == Constant.DIAMOND)
                    _hintDiamond.Draw(graphics);
            }
        }

        //滑鼠按鍵釋放後決定最後一個點
        private void SetFinalPoint(double x2, double y2)
        {
            if (this.Status == Constant.LINE)
            {
                CreateLine(x2, y2);
            }
            else if (this.Status == Constant.DIAMOND)
            {
                CreateDiamond(x2, y2);
            }
        }

        //new Line
        private void CreateLine(double x2, double y2)
        {
            Line line = new Line();
            line.x1 = _point.FirstPoint_X;
            line.y1 = _point.FirstPoint_Y;
            line.x2 = x2;
            line.y2 = y2;
            _commandManager.Execute(new DrawCommand(this,line));
        }

        //new Diamond
        private void CreateDiamond(double x2, double y2)
        {
            Diamond diamond = new Diamond();
            diamond.x1 = _point.FirstPoint_X;
            diamond.y1 = _point.FirstPoint_Y;
            diamond.x2 = x2;
            diamond.y2 = y2;
            _commandManager.Execute(new DrawCommand(this, diamond));
        }

        //設定Hint 第一個點
        private void SetHintPointFirst(double x1, double y1)
        {
            if (this.Status == Constant.LINE)
            {
                _hintLine.x1 = x1;
                _hintLine.y1 = y1;
            }
            else if (this.Status == Constant.DIAMOND)
            {
                _hintDiamond.x1 = x1;
                _hintDiamond.y1 = y1;
            }
        }

        //設定Hint 第二個點
        private void SetHintPointLast(double x2, double y2)
        {
            if (this.Status == Constant.LINE)
            {
                _hintLine.x2 = x2;
                _hintLine.y2 = y2;
            }
            else if (this.Status == Constant.DIAMOND)
            {
                _hintDiamond.x2 = x2;
                _hintDiamond.y2 = y2;
            }
        }

        //將Shape存到List裡面
        public void DrawShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        //將Shape從List刪除
        public void DeleteShape()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }
    }
}
