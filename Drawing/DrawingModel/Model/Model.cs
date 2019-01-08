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
        private Ellipse _hintEllipses;
        private Points _point = new Points();
        private string _status;
        private ShapeFactory _shapeFactory = new ShapeFactory();
        private IState _state;
        private Shape _selectedShape;
        private double _pressPointX;
        private double _pressPointY;

        public Model()
        {
            this.State = new PointerState();
        }

        //移動圖片-點下
        public void IsInRange(double pointX, double pointY)
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].DetectInRange(pointX, pointY))
                {
                    _pressPointX = _point.LastPoint_X = pointX;
                    _pressPointY = _point.LastPoint_Y = pointY;
                    _selectedShape = _shapes[i];
                    break;
                }
            }
        }

        //移動圖片-滑鼠移動
        public void MoveShapeMoving(double pointX, double pointY)
        {
            if (_selectedShape != null)
            {
                _selectedShape.x1 -= (_point.LastPoint_X - pointX);
                _selectedShape.x2 -= (_point.LastPoint_X - pointX);
                _selectedShape.y1 -= (_point.LastPoint_Y - pointY);
                _selectedShape.y2 -= (_point.LastPoint_Y - pointY);
                _point.LastPoint_X = pointX;
                _point.LastPoint_Y = pointY;
                NotifyModelChanged();
            }
        }

        //移動圖片-釋放
        public void MoveShapeReleased(double pointX, double pointY)
        {
            if (_selectedShape != null)
            {
                _selectedShape.x1 += (_pressPointX - pointX);
                _selectedShape.x2 += (_pressPointX - pointX);
                _selectedShape.y1 += (_pressPointY - pointY);
                _selectedShape.y2 += (_pressPointY - pointY);
                _commandManager.Execute(new MoveCommand(this, _selectedShape, pointX, pointY, _pressPointX, _pressPointY));
                _selectedShape = null;
            }
                
        }

        //將移動圖片重新給值
        public void MoveShapePoint(Shape shape, double pointX, double pointY, double firstPointX, double firstPointY)
        {
            shape.x1 -= (firstPointX - pointX);
            shape.x2 -= (firstPointX - pointX);
            shape.y1 -= (firstPointY - pointY);
            shape.y2 -= (firstPointY - pointY);
        }

        //滑鼠點下
        public void PressPointer(double x1, double y1)
        {
            _hintLine = new Line();
            _hintDiamond = new Diamond();
            _hintEllipses = new Ellipse();
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
                else if (this.Status == Constant.ELLIPSE)
                    _hintEllipses.Draw(graphics);
            }
        }

        //滑鼠按鍵釋放後決定最後一個點
        private void SetFinalPoint(double x2, double y2)
        {
            Shape shape = _shapeFactory.CreateShape(this.Status);
            shape.x1 = _point.FirstPoint_X;
            shape.y1 = _point.FirstPoint_Y;
            shape.x2 = x2;
            shape.y2 = y2;
            _commandManager.Execute(new DrawCommand(this, shape));
            ChangeState(Constant.POINTER_STATE);
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
            else if (this.Status == Constant.ELLIPSE)
            {
                _hintEllipses.x1 = x1;
                _hintEllipses.y1 = y1;
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
            else if (this.Status == Constant.ELLIPSE)
            {
                _hintEllipses.x2 = x2;
                _hintEllipses.y2 = y2;
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
