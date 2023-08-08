using System.Windows;
using System.Windows.Controls;
using LibMatrix;
using Lib_11;

namespace Practoc3
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
        Matrix<int> matr = new Matrix<int>(0, 0);
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (matr.Rows != 0 && matr.Columns != 0)
            {
                Decision.Text = $"{ExtensionMatrix.Difference(matr)}";
            }
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(RowsCount.Text, out int rows))
            {
                MessageBox.Show("Введите числовое значение");
                RowsCount.Clear();
            }
            if (!int.TryParse(ColumnCount.Text, out int columns))
            {
                MessageBox.Show("Введите числовое значение");
                ColumnCount.Clear();
            }
            ExtensionMatrix.FillMatrix(matr, rows, columns);
            DataGrid.ItemsSource = matr.ToDataTable().DefaultView;
        }

        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №3\nНайти разницу чисел. Результат вывести на экран.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            matr.Deserialize(@".\matr.txt");
            DataGrid.ItemsSource = matr.ToDataTable().DefaultView;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            matr.Serialize(@".\matr.txt");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            matr.DefaultInit();
            DataGrid.ItemsSource = null;
            RowsCount.Clear();
            ColumnCount.Clear();
            RowsCount.Focus();
            Decision.Clear();
        }

        private void RowsCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid.ItemsSource = null;
            Decision.Clear();
        }

        private void ColumnCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid.ItemsSource = null;
            Decision.Clear();
        }
    }
}
