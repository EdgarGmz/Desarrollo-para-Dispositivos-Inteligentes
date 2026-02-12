namespace ActFinal
{
    public partial class MainPage : ContentPage
    {
        // Tipo de Cambio
        private const decimal Tipo_Cambio_Pesos_A_Dolares = 0.056m;
        private const decimal Tipo_Cambio_Dolares_A_Pesos = 18.00m;

        public MainPage()
        {
            InitializeComponent();
        }
        public  void BtnConvertir_Clicked(object sender, EventArgs e)
        {
            // Validar entrada de datos
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                DisplayAlertAsync("Aviso", "Por favor ingrese un monto valido", "Ok");
                return;
            }

            // Validar seleccion en el picker
            if(ListaConversion.SelectedIndex == -1)
            {
                DisplayAlertAsync("Aviso", "Seleccione un tipo de conversion", "Ok");
                return;
            }

            // Realizar las conversiones
            decimal resultado = 0;
            decimal monto = decimal.Parse(txtMonto.Text);
            if (ListaConversion.SelectedIndex == 0)
            {
                resultado = monto * Tipo_Cambio_Pesos_A_Dolares; 
                lblResultado.Text = resultado.ToString();
            } else if (ListaConversion.SelectedIndex == 1)
            {
                resultado = monto * Tipo_Cambio_Dolares_A_Pesos;
                lblResultado.Text = resultado.ToString();
            }
        }
    }
}
