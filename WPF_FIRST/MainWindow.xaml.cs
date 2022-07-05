using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_FIRST
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public float out_val = 0;
        string in1 = "";
        Model data = new Model();
        ViewModel viewModel;

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Console.WriteLine("1111");
                  }));
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            viewModel=new ViewModel(data);
            this.DataContext = viewModel;
            
           

           
           
            
        }
        private void button1_Click(object sender, RoutedEventArgs e)

        {
            Button button = (Button)sender;
            if (in1 == "")
            {
                textBox_in1.Text = textBox_in1.Text + button.Content;
                data.S1 = data.S1 + button.Content;
            }
            if (in1 != "")
            {
                textBox_in2.Text = textBox_in2.Text + button.Content;
                data.S2 = data.S2 + button.Content;
            }


        }

        //private void button2_Click(object sender, RoutedEventArgs e)
        //{
        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "2";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "2";
        
        //}

        //private void button3_Click(object sender, RoutedEventArgs e)
        //{

        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "3";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "3";

        //}

        //private void button4_Click(object sender, RoutedEventArgs e)
        //{

        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "4";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "4";

        //}

        //private void button5_Click(object sender, RoutedEventArgs e)
        //{
        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "5";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "5";
        //}

        //private void button6_Click(object sender, RoutedEventArgs e)
        //{
        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "6";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "6";
        //}

        //private void button7_Click(object sender, RoutedEventArgs e)
        //{
        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "7";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "7";
        //}

        //private void button8_Click(object sender, RoutedEventArgs e)
        //{
        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "8";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "8";
        //}

        //private void button9_Click(object sender, RoutedEventArgs e)
        //{
        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "9";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "9";
        //}

        //private void button0_Click(object sender, RoutedEventArgs e)
        //{
        //    if (in1 == "")
        //        textBox_in1.Text = textBox_in1.Text + "0";
        //    if (in1 != "")
        //        textBox_in2.Text = textBox_in2.Text + "0";
        //}

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            #region удалить
            textBox_out.Text = "";
            textBox_in1.Text = "";
            textBox_in2.Text = textBox_in1.Text;
            in1 = textBox_in1.Text;
            out_val = 0;
            #endregion
            data.S1 = "";
            data.S2 = "";
            data.Total = "";
            in1 = "";
            out_val = 0;



        }

        private void button_div_Click(object sender, RoutedEventArgs e)
        {
            in1 = textBox_in1.Text;
            textBox_sign.Text = "/";
        }

        private void button_mull_Click(object sender, RoutedEventArgs e)
        {
            in1 = textBox_in1.Text;
            textBox_sign.Text = "x";
            textBox_in1.Foreground = Brushes.Gray;

        }

        private void button_sub_Click(object sender, RoutedEventArgs e)
        {
            in1 = textBox_in1.Text;
            textBox_sign.Text = "-";
            textBox_in1.Foreground = Brushes.Gray;
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            in1 = textBox_in1.Text;
            textBox_sign.Text = "+";
            textBox_in1.Foreground = Brushes.Gray;
        }

        private void button_enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region удалить
                if (textBox_sign.Text == "+")
                    out_val = float.Parse(textBox_in1.Text) + float.Parse(textBox_in2.Text);
                if (textBox_sign.Text == "-")
                    out_val = float.Parse(textBox_in1.Text) - float.Parse(textBox_in2.Text);
                if (textBox_sign.Text == "/")
                    out_val = float.Parse(textBox_in1.Text) / float.Parse(textBox_in2.Text);
                if (textBox_sign.Text == "x")
                    out_val = float.Parse(textBox_in1.Text) * float.Parse(textBox_in2.Text);
                textBox_out.Text = out_val.ToString();
                #endregion


                data.Total = textBox_out.Text;
                if (textBox_sign.Text == "+")
                {
                    data.add();
                }
                if (textBox_sign.Text == "-")
                {
                    data.sub();
                }
                if (textBox_sign.Text == "/")
                {
                    data.div();
                }
                if (textBox_sign.Text == "x") { data.mul(); }
                    
               



            }

            catch (Exception)

            {

                textBox_out.Text = "Некорректный ввод";
                Console.WriteLine(" Неккоректный ввод");
            }



        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            if ((textBox_in1.Text.Length != 0) && (in1 == ""))
                textBox_in1.Text = textBox_in1.Text.Remove(textBox_in1.Text.Length - 1, 1);
            if ((textBox_in2.Text.Length != 0) && (in1 != ""))
                textBox_in2.Text = textBox_in2.Text.Remove(textBox_in2.Text.Length - 1, 1);


        }

        private void button_point_Click(object sender, RoutedEventArgs e)
        {
            #region удалить
            if ((in1 == "") && (textBox_in1.Text.Contains(",") != true))
            {
                textBox_in1.Text = textBox_in1.Text + ",";
            }
               
            if ((in1 != "") && (textBox_in2.Text.Contains(",") != true))
            {
                textBox_in2.Text = textBox_in2.Text + ",";
            }
            #endregion

            //Call ModelMethod
            if ((in1 == "") == true)
            {
                data.S1 = data.enter_pointer(data.S1);
            }
            if ((in1 != "") == true)
            {
                data.S2 = data.enter_pointer(data.S2);
            }



        }

        private void button_1divx_Click(object sender, RoutedEventArgs e)
        {
            textBox_in2.Text = "";
            textBox_sign.Text = "1/x";
            try
            {
                out_val = 1 / float.Parse(textBox_in1.Text);
                textBox_out.Text = out_val.ToString();
            }
            catch (Exception)

            {

                textBox_out.Text = "Некорректный ввод";
                Console.WriteLine(" Неккоректный ввод");
            }

        }

        private void button_x2_Click(object sender, RoutedEventArgs e)
        {
            textBox_in2.Text = "";
            textBox_sign.Text = "x²";
            try
            {
                out_val = float.Parse(textBox_in1.Text) * float.Parse(textBox_in1.Text);
                textBox_out.Text = out_val.ToString();
            }
            catch (Exception)

            {

                textBox_out.Text = "Некорректный ввод";
                Console.WriteLine(" Неккоректный ввод");
            }

        }

        private void textBox_in1_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        
    }
}
  