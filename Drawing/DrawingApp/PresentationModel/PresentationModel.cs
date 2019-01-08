using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel.Interface;
using DrawingModel.Model;
using System.ComponentModel;

namespace DrawingApp
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Model _model;
        IGraphics _graphics;
        private bool _isLineButtonPress = true;
        private bool _isDiamondButtonPress = true;
        private bool _isEllipseButtonPress = true;

        public PresentationModel(Model model, Canvas canvas)
        {
            this._model = model;
            _graphics = new WindowsStoreGraphicsAdaptor(canvas);
        }

        //畫圖
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_graphics);
        }

        //設定狀態，目前是哪一種圖形
        public void SetStatus(string status)
        {
            SetButtonEnabled(status);
            Notify(Constant.IS_DIAMOND_BUTTON_PRESS);
            Notify(Constant.IS_LINE_BUTTON_PRESS);
            Notify(Constant.IS_ELLIPSES_BUTTON_PRESS);
        }

        //設定按鈕狀態
        private void SetButtonEnabled(string status)
        {
            _isDiamondButtonPress = status != Constant.DIAMOND;
            _isLineButtonPress = status != Constant.LINE;
            _isEllipseButtonPress = status != Constant.ELLIPSE;
        }

        //通知畫面更改
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsLineButtonPress
        {
            get
            {
                return _isLineButtonPress;
            }
            set
            {
                _isLineButtonPress = value;
            }
        }

        public bool IsDiamondButtonPress
        {
            get
            {
                return _isDiamondButtonPress;
            }
            set
            {
                _isDiamondButtonPress = value;
            }
        }

        public bool IsEllipseButtonPress
        {
            get
            {
                return _isEllipseButtonPress;
            }
            set
            {
                _isEllipseButtonPress = value;
            }
        }
    }
}
