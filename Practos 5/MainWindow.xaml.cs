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

namespace Practos_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №5\nСоздать класс Pair (пара четных чисел). Создать необходимые методы и свойства. \r\nОпределить метод перемножения пар (а, b) * (с, d) = (а * c, b * d). Создать \r\nперегруженный метод для удвоения пары чисел.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Check(out Pair pair1, out Pair pair2)
        {
            if (!int.TryParse(Input_FirstPair_1.Text, out int Fp1))
            {
                MessageBox.Show("Введите целое число");
                Input_FirstPair_1.Clear();
            }
            if (!int.TryParse(Input_FirstPair_2.Text, out int Fp2))
            {
                MessageBox.Show("Введите целое число");
                Input_FirstPair_2.Clear();
            }
            if (!int.TryParse(Input_SecondPair_1.Text, out int Sp1))
            {
                MessageBox.Show("Введите целое число");
                Input_SecondPair_1.Clear();
            }
            if (!int.TryParse(Input_SecondPair_2.Text, out int Sp2))
            {
                MessageBox.Show("Введите целое число");
                Input_SecondPair_2.Clear();
            }
            pair1 = new Pair(Fp1, Fp2);
            pair2 = new Pair(Sp1, Sp2);
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            Check(out Pair pair1, out Pair pair2);
            Pair pair = pair1.Multiplication(pair2);
            Res_Multiplication.Text = $"{pair.OneValue} {pair.TwoValue}";
        }

        private void Doubling_Click(object sender, RoutedEventArgs e)
        {
            Check(out Pair pair1, out Pair pair2);
            pair1.Multiplication();
            pair2.Multiplication();
            FirstPair_doubled.Text = $"{pair1.OneValue} {pair1.TwoValue}";
            SecondPair_doubled.Text = $"{pair2.OneValue} {pair2.TwoValue}";
        }
    }
}
