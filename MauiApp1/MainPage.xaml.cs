namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private string Validar(double imc)
        {
            string resultado = "";
            // Validaciones
            if (imc < 18.5)
            {
                resultado = "Tiene bajo peso";
            }
            else if (imc >= 18.5 && imc <= 24.9)
            {
                resultado = "Tiene un peso normal";
            }
            else if (imc >= 25 && imc <= 29.9)
            {
                resultado = "Tiene Obesidad";
            }
            else
            {
                resultado = "Ve y checate urgentemente";
            }

                return resultado;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Datos de entrada
            var altura = double.Parse(txtAltura.Text);
            var peso = double.Parse(txtPeso.Text);           

            var IMC = peso / (altura * altura);

            var resultado = Validar(IMC);            

            // Datos de Salida
            DisplayAlertAsync("Aviso", resultado, "ok");
        }
    
    }
}
