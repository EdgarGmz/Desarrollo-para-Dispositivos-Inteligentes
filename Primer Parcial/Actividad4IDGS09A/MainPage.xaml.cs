namespace Actividad4IDGS09A
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnConvertir_Clicked(object sender, EventArgs e)
        {
            // Variables
            string medida_01 = lista_01.SelectedItem as string;
            string medida_02 = lista_02.SelectedItem as string;
            double valor = double.Parse(txtValor.Text);
            double res = 0;

            // Validacion Medida #1
            if (string.IsNullOrEmpty(medida_01))
            {
                DisplayAlertAsync("Aviso", "Debe seleccionar una medida", "Ok");
                return;
            }

            // Validación Medida #2
            if (string.IsNullOrEmpty(medida_02))
            {
                DisplayAlertAsync("Aviso", "Debe seleccionar una medida", "Ok");
                return;
            }

            // Medida #1 y Medida #2 deben ser distintos
            if(medida_01 == medida_02)
            {
                DisplayAlertAsync("Aviso", "Las medidas deben ser diferentes", "Ok");
                return;
            } else if (medida_01 == "Centímetros" && medida_02 == "Metros")
            {
                res = valor * 0.01;
            } else if(medida_01 == "Centímetros" && medida_02 == "Kilómetros")
            {
                res = valor * 1e-5;
            } else if (medida_01 == "Metros" && medida_02 == "Centímetros")
            {
                res = valor * 100;
            } else if(medida_01 == "metros" && medida_02 == "Kilómetros")
            {
                res = valor * 0.001;
            }else if(medida_01 == "Kilómetros" && medida_02 == "Centímetros")
            {
                res = valor * 100000;
            }else if(medida_01 == "Kilómetros" && medida_02 == "Metros")
            {
                res = valor * 1000;
            }

            lblResultado.Text = res.ToString();
        }
    }
}
