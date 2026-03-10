using AppEventos.Models;
using AppEventos.ViewModels;

namespace AppEventos
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.CargaPartidos();
            PartidosList.ItemsSource = viewModel.Partidos;
        }

        private async void PartidosList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection.FirstOrDefault() is Partido partido)
            {
                // Manda a llamar otra pantalla de detalle
                await this.Navigation.PushAsync(new DetallePage(partido));
                
                PartidosList.SelectedItem = null;
            }
        }
    }
}
