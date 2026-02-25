namespace AppImagenPDF
{
    public partial class MainPage : ContentPage
    {
        // Variables
        string imagePath = null;


        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSeleccionarImagen_Clicked(object sender, EventArgs e)
        {
            try
            {
                var file = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Selecciona una Imagen",
                    FileTypes = FilePickerFileType.Images
                });

                if (file != null) 
                {
                    imagePath = file.FullPath;

                    SelectedImage.Source = ImageSource.FromFile(imagePath);
                }
            }
            catch (Exception ex) 
            {
                await DisplayAlertAsync("Error", ex.Message, "Ok");
            }
        }

        private async void btnGenerarPDF_Clicked(object sender, EventArgs e)
        {
            // Validar que hallamos seleccionado una imagen
            if (string.IsNullOrEmpty(imagePath))
            {
                await DisplayAlertAsync("AVISO", "Primero seleccione la imagen", "Ok");
                return;
            }

            var pdfBytes = PDFGenerator.GeneratePDFWithImage(imagePath);

#if ANDROID
    string filePath = Path.Combine(FileSystem.CacheDirectory, "imagen_pdf.pdf");

#elif WINDOWS
    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "imagen_pdf.pdf");

#else
            string filePath = Path.Combine(FileSystem.CacheDirectory, "imagen_pdf.pdf");

#endif
            File.WriteAllBytes(filePath, pdfBytes);

            await DisplayAlertAsync("EXITO", $"PDF guardado en: {filePath} exitosamente!", "OK");
        }
    }
}
