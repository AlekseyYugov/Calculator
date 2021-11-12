using System;
using System.Data;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        int dotted = 0;
        private void but_с_Clicked(object sender, EventArgs e)
        {
            Input.Text = null;
            Input.Text = "0";
            but_dot.IsEnabled = true;
            Funck1(sender, e);
        }

        private void but_ce_Clicked(object sender, EventArgs e)
        {
            Funck1(sender, e);
            char str = '0';
            string number = Input.Text;
            string number2 = Input.Text;
            int i = 0;
            for (; i < Input.Text.Length; i++)
            {
                str = Input.Text[i];
            }
            if (str == '.')
            {
                dotted--;
                but_dot.IsEnabled = true;
            }


            if (str == '-' || str == '+' || str == '*' || str == '/')
            {
                string stroka = null;
                for (int k = 0; k < Input.Text.Length; k++)
                {
                    if (Input.Text[k] != '-' || Input.Text[k] != '+' || Input.Text[k] != '*' || Input.Text[k] != '/')
                    {
                        stroka += Input.Text[k];
                        for (int n = 0; n < stroka.Length; n++)
                        {
                            if (stroka[n] == '.')
                            {
                                but_dot.IsEnabled = false;
                            }
                        }

                    }
                    else
                    {
                        but_dot.IsEnabled = true;
                    }
                }

            }
            if (number != "0")
            {
                if (Input.Text.Length > 1)
                {
                    Funck1(sender, e);
                }
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    Input.Text = "0";
                }
                else
                {
                    Input.Text = number;
                }
            }

        }

        private async void but_proc_Clicked(object sender, EventArgs e)
        {
            string str = Input.Text;
            int size = Input.Text.Length - 1;
            int index = -1;
            string ostatok = null;
            double number = 0;
            string str2 = null;
            try
            {
                for (int i = 0; i < Input.Text.Length; i++)
                {
                    if (str[i] == '-' || str[i] == '+' || str[i] == '*' || str[i] == '/')
                    {
                        index = i;
                    }
                }
                if (str == "0" || str == null)
                {
                    Input.Text = "0";
                }
                else
                if (str[0] == '-' && index == 0)
                {
                    for (int i = index + 1; i < str.Length; i++)
                    {
                        str2 += str[i];
                    }
                    number = Convert.ToDouble(str2) / 100;
                    but_ce_Clicked(sender, e);
                    Input.Text = Convert.ToString(str[index]);
                    Input.Text += number;
                }
                else
                if (index == -1)
                {
                    number = Convert.ToDouble(str) / 100;
                    Input.Text = Convert.ToString(number);
                    foreach (var item in Convert.ToString(number))
                    {
                        if (item == '.')
                        {
                            but_dot.IsEnabled = false;
                        }
                    }
                }
                else
                if (str[index] == '+' || str[index] == '-')
                {
                    for (int i = index + 1; i < str.Length; i++)
                    {
                        ostatok += str[i];
                    }
                    Input.Text = Input.Text.Remove(index, Input.Text.Length - index);
                    but_itog_Clicked(sender, e);
                    number = Convert.ToDouble(Input.Text) / 100;
                    number = number * Convert.ToDouble(ostatok);
                    foreach (var item in Convert.ToString(number))
                    {
                        if (item == '.')
                        {
                            but_dot.IsEnabled = false;
                        }
                    }
                    Input.Text += str[index];
                    Input.Text += number;
                }
                else if (str[index] == '*' || str[index] == '/')
                {
                    for (int i = index + 1; i < str.Length; i++)
                    {
                        ostatok += str[i];
                    }
                    Input.Text = Input.Text.Remove(index, Input.Text.Length - index);
                    number = Convert.ToDouble(ostatok) / 100;
                    foreach (var item in Convert.ToString(number))
                    {
                        if (item == '.')
                        {
                            but_dot.IsEnabled = false;
                        }
                    }
                    Input.Text += str[index];
                    Input.Text += number;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

        }

        private void but_delen_Clicked(object sender, EventArgs e)
        {
            if (Input.Text != "0"
                && Input.Text[Input.Text.Length - 1] != '%'     //переделать
                && Input.Text[Input.Text.Length - 1] != '/'
                && Input.Text[Input.Text.Length - 1] != '*'
                && Input.Text[Input.Text.Length - 1] != '-'
                && Input.Text[Input.Text.Length - 1] != '+'
                && Input.Text[Input.Text.Length - 1] != '.')
            {
                Input.Text += "/";
                but_dot.IsEnabled = true;
                Funck1(sender, e);
            }

        }

        private void but_1_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 1;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 1;
                    }
                    else
                    {
                        Input.Text += 1;
                    }
                }
                else
                {
                    Input.Text += 1;
                }
            }


        }

        private void but_2_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 2;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 2;
                    }
                    else
                    {
                        Input.Text += 2;
                    }
                }
                else
                {
                    Input.Text += 2;
                }
            }
        }

        private void but_3_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 3;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 3;
                    }
                    else
                    {
                        Input.Text += 3;
                    }
                }
                else
                {
                    Input.Text += 3;
                }
            }
        }

        private void but_umnoj_Clicked(object sender, EventArgs e)
        {
            if (Input.Text != "0"
                && Input.Text[Input.Text.Length - 1] != '%'     //переделать
                && Input.Text[Input.Text.Length - 1] != '/'
                && Input.Text[Input.Text.Length - 1] != '*'
                && Input.Text[Input.Text.Length - 1] != '-'
                && Input.Text[Input.Text.Length - 1] != '+'
                && Input.Text[Input.Text.Length - 1] != '.')
            {
                Input.Text += "*";
                but_dot.IsEnabled = true;
                Funck1(sender, e);
            }

        }

        private void but_4_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 4;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 4;
                    }
                    else
                    {
                        Input.Text += 4;
                    }
                }
                else
                {
                    Input.Text += 4;
                }
            }
        }

        private void but_5_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 5;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 5;
                    }
                    else
                    {
                        Input.Text += 5;
                    }
                }
                else
                {
                    Input.Text += 5;
                }
            }
        }

        private void but_6_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 6;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 6;
                    }
                    else
                    {
                        Input.Text += 6;
                    }
                }
                else
                {
                    Input.Text += 6;
                }
            }
        }

        private void but_minus_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += "-";
                but_dot.IsEnabled = true;
                Funck1(sender, e);
            }
            char num = Input.Text[Input.Text.Length - 1];

            if (num != '-' && num != '.')
            {
                Input.Text += "-";
                but_dot.IsEnabled = true;
                Funck1(sender, e);
            }

        }

        private void but_7_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 7;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 7;
                    }
                    else
                    {
                        Input.Text += 7;
                    }
                }
                else
                {
                    Input.Text += 7;
                }
            }
        }

        private void but_8_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 8;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 8;
                    }
                    else
                    {
                        Input.Text += 8;
                    }
                }
                else
                {
                    Input.Text += 8;
                }
            }
        }

        private void but_9_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 9;

            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '0')
                {
                    if (Input.Text[Input.Text.Length - 2] == '+' || Input.Text[Input.Text.Length - 2] == '-' || Input.Text[Input.Text.Length - 2] == '*' || Input.Text[Input.Text.Length - 2] == '/')
                    {

                        Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                        Input.Text += 9;
                    }
                    else
                    {
                        Input.Text += 9;
                    }
                }
                else
                {
                    Input.Text += 9;
                }
            }
        }

        private void but_plus_Clicked(object sender, EventArgs e)
        {
            if (Input.Text != "0"
                && Input.Text[Input.Text.Length - 1] != '%'     //переделать
                && Input.Text[Input.Text.Length - 1] != '/'
                && Input.Text[Input.Text.Length - 1] != '*'
                && Input.Text[Input.Text.Length - 1] != '-'
                && Input.Text[Input.Text.Length - 1] != '+'
                && Input.Text[Input.Text.Length - 1] != '.')
            {
                Input.Text += "+";
                but_dot.IsEnabled = true;
                Funck1(sender, e);
            }

        }

        private void but_dot_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == null)
            {
                Input.Text = "0";
            }
            if (Input.Text == "0"
                || Input.Text[Input.Text.Length - 1] == '0'
                || Input.Text[Input.Text.Length - 1] == '1'     //переделать
                || Input.Text[Input.Text.Length - 1] == '2'
                || Input.Text[Input.Text.Length - 1] == '3'
                || Input.Text[Input.Text.Length - 1] == '4'
                || Input.Text[Input.Text.Length - 1] == '5'
                || Input.Text[Input.Text.Length - 1] == '6'
                || Input.Text[Input.Text.Length - 1] == '7'
                || Input.Text[Input.Text.Length - 1] == '8'
                || Input.Text[Input.Text.Length - 1] == '9')
            {

                Input.Text += ".";
                dotted++;
                but_dot.IsEnabled = false;
                Funck1(sender, e);
            }

        }

        private void but_0_Clicked(object sender, EventArgs e)
        {
            if (Input.Text == "0")
            {
                Input.Text = null;
                Input.Text += 0;
            }
            else
            {
                char lastinput = Input.Text[Input.Text.Length - 1];
                if (lastinput == '0')
                {
                    char lastlastinput = Input.Text[Input.Text.Length - 2];
                    if (lastlastinput == '+' || lastlastinput == '-' || lastlastinput == '*' || lastlastinput == '/')
                    {
                        but_dot_Clicked(sender, e);
                        but_dot.IsEnabled = false;
                    }


                }
                if (lastinput == '+' || lastinput == '-' || lastinput == '*' || lastinput == '/')
                {
                    Input.Text += 0;
                    Funck0(sender, e);
                }
                else
                {
                    Input.Text += 0;
                }

            }
        }

        private void Funck0(object sender, EventArgs e) // закрывает доступ к кнопкам 0-9
        {
            but_0.IsEnabled = false;
            but_1.IsEnabled = false;
            but_2.IsEnabled = false;
            but_3.IsEnabled = false;
            but_4.IsEnabled = false;
            but_5.IsEnabled = false;
            but_6.IsEnabled = false;
            but_7.IsEnabled = false;
            but_8.IsEnabled = false;
            but_9.IsEnabled = false;
        }

        private void Funck1(object sender, EventArgs e) // открывает доступ к кнопкам 0-9
        {
            but_0.IsEnabled = true;
            but_1.IsEnabled = true;
            but_2.IsEnabled = true;
            but_3.IsEnabled = true;
            but_4.IsEnabled = true;
            but_5.IsEnabled = true;
            but_6.IsEnabled = true;
            but_7.IsEnabled = true;
            but_8.IsEnabled = true;
            but_9.IsEnabled = true;
        }

        private async void but_itog_Clicked(object sender, EventArgs e)
        {


            try
            {
                if (Input.Text[Input.Text.Length - 1] == '-' ||
                Input.Text[Input.Text.Length - 1] == '+' ||
                Input.Text[Input.Text.Length - 1] == '*' ||
                Input.Text[Input.Text.Length - 1] == '/')
                {
                    Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                }
                if (Input.Text[Input.Text.Length - 1] == '0' &&
                Input.Text[Input.Text.Length - 1] == '/')
                {
                    Input.Text = "0";
                }

                string value = new DataTable().Compute(Input.Text, null).ToString();

                Input.Text = value;
                but_dot.IsEnabled = true;
                bool exit = false;
                for (int i = 0; i < Input.Text.Length; i++)
                {
                    if (Input.Text[i] == '.')
                    {
                        exit = true;
                    }
                }
                if (exit == true)
                {
                    but_dot.IsEnabled = false;

                }
                Funck1(sender, e);

                int num = Input.Text.Length - 1;
                for (int i = 0; i < Input.Text.Length; i++)
                {
                    if (Input.Text[i] == '.')
                    {
                        while (value[num] == '0')
                        {
                            value = value.Remove(num, 1);
                            num--;
                        }
                        Input.Text = value;
                    }
                }
                if (Input.Text[Input.Text.Length - 1] == '.')
                {
                    Input.Text = Input.Text.Remove(Input.Text.Length - 1, 1);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

        }

    }
}

