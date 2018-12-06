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
            InitializeComponent();
            _model = model;
            _presentationModel = new PresentationModel(_model);
            _drawingPanel = new DoubleBufferedPanel();
        }

        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            
        }

        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
        }

        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
        }

        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
        }

        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
        }
    }
}
