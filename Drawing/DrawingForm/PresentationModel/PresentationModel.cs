using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel.Model;

namespace DrawingForm
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model = new Model();
        private bool _isLineButtonPress = true;
        private bool _isDiamondButtonPress = true;
        private bool _isEllipsesButtonPress = true;
        public PresentationModel(Model model)
        {
            _model = model;
        }

        //畫圖
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
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
            _isEllipsesButtonPress = status != Constant.ELLIPSES;
        }

        //通知畫面更改
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsEllipsesButtonPress
        {
            get
            {
                return _isEllipsesButtonPress;
            }
            set
            {
                _isEllipsesButtonPress = value;
            }
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
    }
}
