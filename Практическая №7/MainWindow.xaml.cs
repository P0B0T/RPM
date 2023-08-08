using Practos_5;
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

namespace Практическая__7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RightAngled triangle = new RightAngled(0,0);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №7\nИспользовать класс Pair (пара четных чисел). Определить производный класс \r\nтреугольник RightAngled с полями-катетами. Определить методы вычисления \r\nгипотенузы и площади треугольника.\r\n");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Check()
        {
            try
            {
                int Firstcathet = Convert.ToInt32(Input_FirstCathet.Text);
                int Secondcathet = Convert.ToInt32(Input_SecondCathet.Text);

                triangle = new RightAngled(Firstcathet, Secondcathet);
            }
            catch (Exception)
            {
                MessageBox.Show("Числа должны быть больше или равны 0");
                Input_FirstCathet.Clear();
                Input_SecondCathet.Clear();
            }
        }

        private void Hypothesis_Click(object sender, RoutedEventArgs e)
        {
            Check();
            Hypothesis_triangle.Text = triangle.Hypothesis(triangle).ToString();
        }

        private void Area_Click(object sender, RoutedEventArgs e)
        {
            Check();
            Area_triangle.Text = triangle.Area(triangle).ToString();
        }
    }
}
