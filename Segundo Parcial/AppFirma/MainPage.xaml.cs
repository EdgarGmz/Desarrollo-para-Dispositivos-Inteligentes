using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;

namespace AppFirma
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<IDrawingLine> Lines { get; set; } = new ObservableCollection<IDrawingLine>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private async void btnDrawingView_DrawingLineCompleted(object sender, DrawingLineCompletedEventArgs e)
        {
            var stream = await e.LastDrawingLine.GetImageStream(400, 200, Colors.Gray.AsPaint());
            drawingImage.Source = ImageSource.FromStream(() => stream);
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            Lines.Clear();
        } 

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var stream = await DrawingView.GetImageStream(Lines, new Size(400, 200), Colors.Gray);
            drawingImage.Source = ImageSource.FromStream(() => stream);
            await DisplayAlert("Éxito", "La imagen ha sido guardada correctamente", "OK");
        }
    }
}
