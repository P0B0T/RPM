using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;

namespace Практическая__12
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
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №12\nРеализовать расчет задачи: Даны координаты двух противоположных вершин прямоугольника: (x1, y1), (x2, y2). Стороны прямоугольника параллельны осям координат. Найти периметр и площадь данного прямоугольника. Дан размер файла в байтах. Используя операцию деления нацело, найти количество полных килобайтов, которые занимает данный файл (1 килобайт = 1024 байта).");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Start1_Click(object sender, RoutedEventArgs e)
        {
            FirstCoordX.Focus();

            if (!int.TryParse(SecondCoordX.Text, out int X2))
            {
                MessageBox.Show("Введите числовые значения");
            }
            if(!int.TryParse(FirstCoordX.Text, out int X1))
            {
                MessageBox.Show("Введите числовые значения");
            }
            if (!int.TryParse(FirstCoordY.Text, out int Y1))
            {
                MessageBox.Show("Введите числовые значения");
            }
            if (!int.TryParse(SecondCoordY.Text, out int Y2))
            {
                MessageBox.Show("Введите числовые значения");
            }

            int a = Math.Abs(X2 - X1);
            int b = Math.Abs(Y2 - Y1);

            int sqare = a * b;

            Sqare.Text = sqare.ToString();

            int perimeter = 2 * (a + b);

            Perimeter.Text = perimeter.ToString();
        }

        private void FirstCoordX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Perimeter.Clear();
            Sqare.Clear();
        }

        private void FirstCoordY_TextChanged(object sender, TextChangedEventArgs e)
        {
            Perimeter.Clear();
            Sqare.Clear();
        }

        private void SecondCoordX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Perimeter.Clear();
            Sqare.Clear();
        }

        private void SecondCoordY_TextChanged(object sender, TextChangedEventArgs e)
        {
            Perimeter.Clear();
            Sqare.Clear();
        }

        private void Start2_Click(object sender, RoutedEventArgs e)
        {
            SizeInByte.Focus();

            if(!int.TryParse(SizeInByte.Text, out int size_byte))
            {
                MessageBox.Show("Введите числовые значения");
            }

            int size_kbyte = size_byte / 1024;

            SizeInKByte.Text = size_kbyte.ToString();
        }

        private void SizeInBsyte_TextChanged(object sender, TextChangedEventArgs e)
        {
            SizeInKByte.Clear();
        }
    }
}
