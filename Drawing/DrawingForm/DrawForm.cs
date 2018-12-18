using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingModel.Model;

namespace DrawingForm
{
    public partial class DrawForm : Form
    {
        private Model _model = new Model();
        private PresentationModel _presentationModel;

        public DrawForm(Model model)
        {
            _drawingPanel = new DoubleBufferedPanel();
            InitializeComponent();
            _model = model;
            _presentationModel = new PresentationModel(_model);
            _lineButton.DataBindings.Add(Constant.ITEM_ENABLED,_presentationModel,Constant.IS_LINE_BUTTON_PRESS);
            _diamondButton.DataBindings.Add(Constant.ITEM_ENABLED,_presentationModel,Constant.IS_DIAMOND_BUTTON_PRESS);
            _model._modelChanged += ChangeHandleModel;
            _clearButton.Click += ClickHandleClearButton;
        }

        //清除按鈕觸發
        public void ClickHandleClearButton(object sender, System.EventArgs e)
        {
            _presentationModel.SetStatus(Constant.CLEAR);
            _model.Clear();
        }

        //滑鼠左鍵按下
        public void PressHandleCanvas(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressPointer(e.X, e.Y);
        }

        //滑鼠左鍵釋放
        public void ReleaseHandleCanvas(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasePointer(e.X, e.Y);
        }

        //滑鼠移動
        public void MoveHandleCanvas(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
        }

        //畫圖
        public void PaintHandleCanvas(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //按下畫線按鈕
        private void ClickLineButton(object sender, EventArgs e)
        {
            _model.Status = Constant.LINE;
            _presentationModel.SetStatus(Constant.LINE);
        }

        //按下畫方塊按鈕
        private void ClickDiamondButton(object sender, EventArgs e)
        {
            _model.Status = Constant.DIAMOND;
            _presentationModel.SetStatus(Constant.DIAMOND);
        }

        //畫面更新
        public void ChangeHandleModel()
        {
            Invalidate(true);
        }
    }
}
