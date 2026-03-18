namespace AppCalculadora
{
    public partial class MainPage : ContentPage
    {
        // Variables
        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;

        public MainPage()
        {
            InitializeComponent();
        }


        private void btnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "0";
            isOperatorClicked = false;
            firstNumber = 0;
        }

        private void btnX_Clicked(object sender, EventArgs e)
        {
            string number = LblResult.Text;
            if(number != "0")
            {
                // Eliminar los elementos del display de deracha a izquierda
                number = number.Remove(number.Length - 1, 1);

                if (string.IsNullOrEmpty(number)) 
                {
                    LblResult.Text = "0";
                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }

        private async void btnPorcentaje_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = LblResult.Text;

                if(number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.00");
                    LblResult.Text = result;
                }
            }
            catch (Exception ex)  
            {
                await DisplayAlertAsync("Error", ex.Message, "OK");
            }
        }

        private void btnCommon(object sender, EventArgs e)
        {
            // Logica para los numeros
            var button = sender as Button;

            if(LblResult.Text == "0" || isOperatorClicked == true)
            {
                isOperatorClicked = false;
                LblResult.Text = button.Text;
            }
            else
            {
                LblResult.Text += button.Text;
            }
        }
        private async void btnEqual_CLicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(LblResult.Text);
                string finalResult = Calcular(firstNumber, secondNumber).ToString("0.##");
                LblResult.Text = finalResult;
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync ("Error", ex.Message, "OK");
            }
        }

        private void btnCommandOperation(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(LblResult.Text);
        }

        private decimal Calcular(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            if (operatorName == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operatorName == "-") 
            {
                result = firstNumber - secondNumber;            
            }
            else if (operatorName == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if(operatorName == "/")
            {
                result = firstNumber / secondNumber;
            }

            return result;
        }
    }
}
