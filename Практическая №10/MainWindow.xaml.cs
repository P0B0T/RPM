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

namespace Практическая__10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> array = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №10\nСоставьте программу вычисления в массиве максимального среди отрицательных элементов и его номера.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            array.Clear();
            ListBox.Items.Clear();

            if(!int.TryParse(Input.Text, out int count))
            {
                MessageBox.Show("Введите длину массива");
            }
            array = new List<int>(count);

            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                array.Add(rnd.Next(-100, 100));
                ListBox.Items.Add(array[i]);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int max = -101;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < 0 && array[i] > max)
                {
                    max = array[i];
                }
            }
            Result_Max.Text = $"{max}";
            Result_IndexMax.Text = array.IndexOf(max).ToString();
            if (max == -101)
            {
                Result_IndexMax.Clear();
                Result_Max.Clear();
                MessageBox.Show("Отрицательных чисел нет");
            }
        }
    }
}
