using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DrawingModel.Model;
using DrawingApp.PresentationModel;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Model _model;
        private PresentationModel.PresentationModel _presentationModel;
        public MainPage()
        {
            this.InitializeComponent();
            _model = new Model();
            _presentationModel = new PresentationModel.PresentationModel(_model,_canvas);

            _canvas.PointerPressed += PressHandleCanvas;
            _canvas.PointerReleased += ReleaseHandleCanvas;
            _canvas.PointerMoved += MoveHandleCanvas;
            _clear.Click += ClickHandleClearButton;
            _model._modelChanged += ChangeHandleModel;
            _line.Click += ClickLineButton;
            _diamond.Click += ClickDiamondButton;
            this.DataContext = _presentationModel;
        }
        
        //Clear Button Click
        private void ClickHandleClearButton(object sender, RoutedEventArgs e)
        {
            _presentationModel.SetStatus(Constant.CLEAR);
            _model.Clear();
        }

        //滑鼠左鍵按下
        public void PressHandleCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //滑鼠左鍵釋放
        public void ReleaseHandleCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //滑鼠移動
        public void MoveHandleCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //按下Line Button
        private void ClickLineButton(object sender, RoutedEventArgs e)
        {
            _model.Status = Constant.LINE;
            _presentationModel.SetStatus(Constant.LINE);
        }

        //按下Diamond按鈕
        private void ClickDiamondButton(object sender, RoutedEventArgs e)
        {
            _model.Status = Constant.DIAMOND;
            _presentationModel.SetStatus(Constant.DIAMOND);
        }

        //畫面更新
        public void ChangeHandleModel()
        {
            _presentationModel.Draw();
        }
    }
}
