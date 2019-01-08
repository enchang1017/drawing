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
        private ToolStripButton _undo;
        private ToolStripButton _redo;

        public DrawForm(Model model)
        {
            _drawingPanel = new DoubleBufferedPanel();
            InitializeComponent();

            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Parent = this;

            _undo = new ToolStripButton("Undo", null, ClickUndoButton);
            _undo.Enabled = false;
            toolStrip.Items.Add(_undo);
            _redo = new ToolStripButton("Redo", null, ClickRedoButton);
            _redo.Enabled = false;
            toolStrip.Items.Add(_redo);

            _model = model;
            _presentationModel = new PresentationModel(_model);
            _lineButton.DataBindings.Add(Constant.ITEM_ENABLED,_presentationModel,Constant.IS_LINE_BUTTON_PRESS);
            _diamondButton.DataBindings.Add(Constant.ITEM_ENABLED,_presentationModel,Constant.IS_DIAMOND_BUTTON_PRESS);
            _ellipseButton.DataBindings.Add(Constant.ITEM_ENABLED,_presentationModel,Constant.IS_ELLIPSES_BUTTON_PRESS);
            _model._modelChanged += ChangeHandleModel;
            _clearButton.Click += ClickHandleClearButton;
            _drawingPanel.MouseDown += PressHandleCanvas;
            _drawingPanel.MouseUp += ReleaseHandleCanvas;
            _drawingPanel.MouseMove += MoveHandleCanvas;
            _drawingPanel.Paint += PaintHandleCanvas;
        }

        //清除按鈕觸發
        public void ClickHandleClearButton(object sender, System.EventArgs e)
        {
            _presentationModel.SetStatus(Constant.CLEAR);
            _model.Status = Constant.CLEAR;
            _model.Clear();
        }

        //滑鼠左鍵按下
        public void PressHandleCanvas(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.GetPressPointerByStatue(e.X, e.Y);
        }

        //滑鼠左鍵釋放
        public void ReleaseHandleCanvas(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var state = _model.GetReleasePointerByStatus(e.X, e.Y);
            if (state == Constant.DRAWING_STATE)
                SetButtonUp();
        }

        //滑鼠移動
        public void MoveHandleCanvas(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.GetMovePointerByStatus(e.X, e.Y);
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
            _model.ChangeState(Constant.DRAWING_STATE);
        }

        //按下畫方塊按鈕
        private void ClickDiamondButton(object sender, EventArgs e)
        {
            _model.Status = Constant.DIAMOND;
            _presentationModel.SetStatus(Constant.DIAMOND);
            _model.ChangeState(Constant.DRAWING_STATE);
        }
        
        //按下Undo
        private void ClickUndoButton(Object sender, EventArgs e)
        {
            _model.Undo();
            ChangeHandleModel();
        }

        //按下Redo
        private void ClickRedoButton(Object sender, EventArgs e)
        {
            _model.Redo();
            ChangeHandleModel();
        }

        //畫面更新
        public void ChangeHandleModel()
        {
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
            Invalidate(true);
        }

        //按下橢圓按鈕
        private void ClickEllipseButton(object sender, EventArgs e)
        {
            _model.Status = Constant.ELLIPSE;
            _presentationModel.SetStatus(Constant.ELLIPSE);
            _model.ChangeState(Constant.DRAWING_STATE);
        }

        //將按鈕設置為true
        private void SetButtonUp()
        {
            _diamondButton.Enabled = true;
            _ellipseButton.Enabled = true;
            _lineButton.Enabled = true;
        }
    }
}
