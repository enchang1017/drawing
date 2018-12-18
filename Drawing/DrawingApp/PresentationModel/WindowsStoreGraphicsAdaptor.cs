using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel.Interface;
using DrawingModel.Model;
using Windows.Foundation;

namespace DrawingApp.PresentationModel
{
    public class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        //清除
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        //畫方塊
        public void DrawDiamond(double x1, double y1, double x2, double y2)
        {
            int middleOfX = (int)(x1 + (x2 - x1) / Constant.DIVISOR);
            int middleOfY = (int)(y1 + (y2 - y1) / Constant.DIVISOR);
            Windows.UI.Xaml.Shapes.Polygon diamond = new Windows.UI.Xaml.Shapes.Polygon();
            PointCollection points = new PointCollection();
            points.Add(new Point(middleOfX, (int)y1));
            points.Add(new Point((int)x1, middleOfY));
            points.Add(new Point(middleOfX, (int)y2));
            points.Add(new Point((int)x2, middleOfY));
            diamond.Points = points;
            diamond.Margin = new Windows.UI.Xaml.Thickness(Constant.MARGIN_NUMBER);
            diamond.Fill = new SolidColorBrush(Colors.Yellow);
            diamond.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(diamond);
        }
    }
}
