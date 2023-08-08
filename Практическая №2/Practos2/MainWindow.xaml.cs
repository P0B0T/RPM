using Lib_11;
using LibArray;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System;

namespace Practos2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Input.Focus();
        }
        Array<int> list = new Array<int>(0);
        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №2\nНайти разницу чисел. Результат вывести на экран.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            list.Deserialize(@".\array.txt");
            DataGrid.ItemsSource = list.ToDataTable().DefaultView;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (list.Capacity != 0)
            {
                list.Serialize(@".\array.txt");
            }
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            bool check = int.TryParse(Input.Text, out int count);
            if (!check)
            {
                MessageBox.Show("Введите числовое значение");
            }
            list = new Array<int>(count);
            list.Init();
            DataGrid.ItemsSource = list.ToDataTable().DefaultView;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            DataGrid.ItemsSource = null;
            Decision.Clear();
            Input.Clear();
            Input_to_work.Clear();
        }

        private void Delete_1_Click(object sender, RoutedEventArgs e)
        {
            string[] str = Input_to_work.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < str.Length; i++)
            {
                if(!int.TryParse(str[i], out int value))
                {
                    continue;
                }
                list.Remove(value);
            }

            DataGrid.ItemsSource = list.ToDataTable().DefaultView;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string[] str = Input_to_work.Text.Split(new string[] {" "}, System.StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int.TryParse(str[i], out int value);
                arr[i] = value;
            } 
            list.AddRange(arr);
            DataGrid.ItemsSource = list.ToDataTable2().DefaultView;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            Decision.Text = $"{list.Difference()}";
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            Decision.Clear();
        }
    }
}
