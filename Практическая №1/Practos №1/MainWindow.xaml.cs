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
using Lib_11;

namespace Practos__1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Input_limit.Focus();
        }

        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №1\nСгенерировать массив заполненный случайными целыми числами, распределенных в диапазоне от 2 до 14. Найти сумму чисел > 5.Вывести на экран сгенерированные числа, значение суммы.В классе реализовать статический метод с именем SumMoreFive.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Input_limit_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sum.Clear();
            Numbers.Clear();
            Input_limit.Focus();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            bool check = int.TryParse(Input_limit.Text, out int limit);
            if (!check)
            {
                MessageBox.Show("Введите числовое значение");
            }
            int[] array = MathString.Init(limit);
            string numbers = string.Join(" ", array);
            Numbers.Text = numbers;
            Sum.Text = Convert.ToString(array.SumMoreFive());
        }
    }
}
