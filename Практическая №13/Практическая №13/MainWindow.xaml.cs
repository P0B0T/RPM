using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMatrix;

namespace Практическая__13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matrix<int> matr = new Matrix<int>(0, 0);
        int[] array;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №13\nДана матрица размера M * N. Для каждого столбца матрицы с четным номером (2, 4, …) найти сумму его элементов. Условный оператор не использовать.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Original_Matr.ItemsSource = null;
            Result_Matr.ItemsSource = null;
            Rows.Clear();
            Columns.Clear();
            Zn_1.Clear();
            Zn_2.Clear();
            Size.Clear();
            Number_cell.Clear();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            string path = @".\matrix" + matr.Extension;
            matr.Open(path);
            Original_Matr.ItemsSource = matr.ToDataTable().DefaultView;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string path = @".\matrix" + matr.Extension;
            matr.Save(path);
            MessageBox.Show("Сохранение прошло успешно");
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (matr.Rows != 0 && matr.Columns != 0)
            {
                array = Fill_and_Calculate.Calculate(matr);
                Result_Matr.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
            }
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Rows.Text, out int rows))
            {
                MessageBox.Show("Введите числовое значение");
                Rows.Clear();
            }
            if (!int.TryParse(Columns.Text, out int columns))
            {
                MessageBox.Show("Введите числовое значение");
                Columns.Clear();
            }
            if (!int.TryParse(Zn_1.Text, out int zn1))
            {
                MessageBox.Show("Введите числовое значение");
                Zn_1.Clear();
            }
            if (!int.TryParse(Zn_2.Text, out int zn2))
            {
                MessageBox.Show("Введите числовое значение");
                Zn_2.Clear();
            }
            Fill_and_Calculate.Fill(matr, rows, columns, zn1, zn2);
            Original_Matr.ItemsSource = matr.ToDataTable().DefaultView;

            Size.Text = $"{rows} x {columns}";
        }

        private void Original_Matr_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Number_cell.Text = $"{e.Row.GetIndex()} x {e.Column.DisplayIndex}";  
        }
    }
}
