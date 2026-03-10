using AppEventos.Models;
namespace AppEventos;

public partial class DetallePage : ContentPage
{
	Partido _partido;
	public DetallePage(Partido partido)
	{
		InitializeComponent();
		_partido = partido;
		BindingContext = _partido;
	}

    private async void btnVerVideo_Clicked(object sender, EventArgs e)
    {
		await Launcher.Default.OpenAsync(_partido.VideoURL);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}