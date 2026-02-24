using Plugin.Maui.Biometric;

namespace Act2_P2
{
    public partial class MainPage : ContentPage
    {
        private int _count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounter_Clicked(object sender, EventArgs e)
        {
            var availability = await BiometricAuthenticationService.Default.GetAuthenticationStatusAsync();
            if (availability != BiometricResponseStatus.Success)
            {
                bool isAuthenticated = await CheckBiometricAuthAsync();

                if (isAuthenticated)
                {
                    UpdateCounter();
                }
                else
                {
                    await DisplayAlertAsync("Autenticación fallida", "Acceso denegado.", "Cerrar");
                }
            }
            else
            {
                await DisplayAlertAsync("Error", "La autenticación biométrica no está disponible en este dispositivo.", "OK");
                return;
            }
        }

        private async Task<bool> CheckBiometricAuthAsync()
        {
            var request = new AuthenticationRequest
            {
                Title = "Autenticación Requerida",
                Subtitle = "Confirma tu identidad para continuar",
                Description = "Usamos biometría para asegurar el contador",
                NegativeText = "Cancelar"
            };

            var result = await BiometricAuthenticationService.Default.AuthenticateAsync(request, CancellationToken.None);
            return result.Status == BiometricResponseStatus.Success;
        }

        private void UpdateCounter()
        {
            // Aseguramos que los cambios de UI ocurran en el hilo principal
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _count++;

                string timesText = _count == 1 ? "vez" : "veces";

                // Actualización de los elementos               
                CounterLabel.Text = $"Incrementado {_count} {timesText}";

                SemanticScreenReader.Announce(CounterBtn.Text);
            });
        }
    }
}