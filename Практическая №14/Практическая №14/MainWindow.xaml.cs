using LibMatrix;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Практическая__14
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
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №14\n1. Создать копию программы из задания №13\r\n2. Добавить окно «Пароль» и организовать авторизацию в программе. Для упрощения проверки пароль задать «123».\r\n3. Создать окно «Настройка». Назначение окна – изменение размера таблицы. При установке размера таблицы сохранять настройки в файл конфигурации «config.ini».\r\n4. При запуске программы задавать размер таблицы согласно файлу конфигурации.\r\n5. Использовать исключения. Например: при чтении файла конфигурации если он отсутствует размер таблицы не задавать.\r\n6. При закрытии программы вывести диалоговое окно с подтверждением завершения работы.\r\n7. Оформить программу комментариями");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult  result;
            result = MessageBox.Show("Закрыть программу?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if(result == MessageBoxResult.Yes)
            {
                Close();
                MessageBox.Show("Если не хотите каждый раз видеть это диалоговое окно, то закрывайте программу через 'крестик'.");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Original_Matr.ItemsSource = null;
            Result_Matr.ItemsSource = null;
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
                array = FillAndCalculate.Calculate(matr);
                Result_Matr.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
            }
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
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
            try
            {
                using (StreamReader reader = new StreamReader("config.ini"))
                {
                    int rows = Convert.ToInt32(reader.ReadLine());
                    int columns = Convert.ToInt32(reader.ReadLine());

                    FillAndCalculate.Fill(matr, rows, columns, zn1, zn2);

                    Size.Text = $"{rows} x {columns}";
                }

                Original_Matr.ItemsSource = matr.ToDataTable().DefaultView;
            }
            catch(Exception)
            {
                MessageBox.Show("Файл настроек не найден. Перейдите в 'Настройки' и задайте параметры матрицы");
            }
            
        }

        private void Original_Matr_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Number_cell.Text = $"{e.Row.GetIndex()} x {e.Column.DisplayIndex}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Authorization pas = new Authorization();
            pas.Owner = this;
            pas.ShowDialog();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Setting settings = new Setting();
            settings.Owner = this;
            settings.ShowDialog();
        }
    }
}
