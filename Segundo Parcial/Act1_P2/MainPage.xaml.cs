namespace Act1_P2
{
    public partial class MainPage : ContentPage
    {
        private IDispatcherTimer _timer;
        private TimeSpan? _alarmTime;

        public MainPage()
        {
            InitializeComponent();
            StartClock(); 
        }

        private void StartClock()
        {
            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) =>
            {
                // Formato corregido: HH:mm:ss
                TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");

                if (_alarmTime.HasValue)
                {
                    var now = DateTime.Now;
                    if (now.Hour == _alarmTime.Value.Hours && now.Minute == _alarmTime.Value.Minutes)
                    {
                        // Usamos una variable local para evitar múltiples disparos
                        var triggeredTime = _alarmTime;
                        _alarmTime = null;
                        ShowAlarmAlert(triggeredTime.Value);
                    }
                }
            };
            _timer.Start();
        }

        private void SetAlarma_Clicked(object sender, EventArgs e)
        {
            _alarmTime = AlarmTimePicker.Time;
            AlarmaStatusLabel.Text = $"Alarma programada para: {_alarmTime.Value:hh\\:mm}";
        }

        private async void ShowAlarmAlert(TimeSpan time)
        {
            await DisplayAlertAsync("Alarma", $"¡Es hora! ({time:hh\\:mm})", "OK");
        }
    }
}
