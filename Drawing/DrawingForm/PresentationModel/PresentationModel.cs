using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel.Model;

namespace DrawingForm
{
    public class PresentationModel
    {
        private Model _model = new Model();
        public PresentationModel(Model model)
        {
            _model = model;
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            //_model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }
    }
}
