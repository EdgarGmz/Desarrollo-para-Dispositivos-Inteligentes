namespace AppCamera3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            var foto = await MediaPicker.Default.CapturePhotoAsync();
            if (foto != null)
            {
                var stream = await foto.OpenReadAsync();
                imgFoto.Source = ImageSource.FromStream(() => stream);
            }

        }

        private async void btnObtenerGaleria_Clicked(object sender, EventArgs e)
        {
            var foto = await MediaPicker.PickPhotoAsync();
            if (foto != null)
            {
                var stream = await foto.OpenReadAsync();
                imgFoto.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}
