using Microsoft.EntityFrameworkCore;
using Pract18.DataBase;
using Pract18.FunctionalWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

namespace Pract18
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportsVeteransGetContext db = SportsVeteransGetContext.GetContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Athletes.Load();

            Bd.ItemsSource = db.Athletes.Local.ToBindingList();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            Addendum addendum = new Addendum();
            addendum.ShowDialog();
            Bd.Focus();
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
            int indexRow = Bd.SelectedIndex;
            if(result == MessageBoxResult.Yes)
            {
                if (indexRow != -1)
                {
                    var item = (Athlete)Bd.Items[indexRow];
                    db.Athletes.Remove(item);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } 
        }

        private void Change_button_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = Bd.SelectedIndex;
            if (indexRow != -1)
            {
                var item = (Athlete)Bd.Items[indexRow];
                Data.Id = item.Id;

                Editing editing = new Editing();
                editing.ShowDialog();

                Bd.Items.Refresh();
                Bd.Focus();
            }
            else MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Origin_button_Click(object sender, RoutedEventArgs e)
        {
            Bd.ItemsSource = db.Athletes.Local.ToBindingList();
        }

        private void Search_button_Click(object sender, RoutedEventArgs e)
        {
            if (Search_TextBox.Text == "Введите код")
            {
                MessageBox.Show("Введите код!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Search_TextBox.Focus();
                return;
            }

            for (int i = 0; i < Bd.Items.Count; i++)
            {
                var row = (Athlete)Bd.Items[i];
                string findContent = row.Id.ToString();

                try
                {
                    if (findContent != null && findContent.Contains(Search_TextBox.Text))
                    {
                        object item = Bd.Items[i];
                        Bd.SelectedItem = item;
                        Bd.ScrollIntoView(item);
                        Bd.Focus();
                        break;
                    }

                    if (!findContent.Contains(Search_TextBox.Text) && i == Bd.Items.Count - 1)
                    {
                        MessageBox.Show("Этого кода нет в базе данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        Search_TextBox.Clear();
                        Search_TextBox.Focus();
                        break;
                    }
                }
                catch { }
            }
        }

        public static string FilterType { get; set; }

        void FilterWindowShow()
        {
            Filter filter = new Filter();
            filter.ShowDialog();
            Bd.Focus();
        }

        private void Filter_Hotel_Click(object sender, RoutedEventArgs e)
        {
            FilterType = "Hotel";
            FilterWindowShow();
            Bd.ItemsSource = Filter.Result.ItemsSource;
        }
        private void Filter_RoomNumber_Click(object sender, RoutedEventArgs e)
        {
            FilterType = "RoomNumber";
            FilterWindowShow();
            Bd.ItemsSource = Filter.Result.ItemsSource;
        }

        private void Filter_AgeGroup_Click(object sender, RoutedEventArgs e)
        {
            FilterType = "AgeGroup";
            FilterWindowShow();
            Bd.ItemsSource = Filter.Result.ItemsSource;
        }

        private void Filter_City_Click(object sender, RoutedEventArgs e)
        {
            FilterType = "City";
            FilterWindowShow();
            Bd.ItemsSource = Filter.Result.ItemsSource;
        }

        private void Filter_SportTipe_Click(object sender, RoutedEventArgs e)
        {
            FilterType = "SportTipe";
            FilterWindowShow();
            Bd.ItemsSource = Filter.Result.ItemsSource;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. Разработать интерфейс для доступа и управления однотабличной базой данных. \r\n2. Создать меню.\r\n3. Использовать кнопки для функций Добавить, Изменить, Просмотр, Удалить.\r\n4. Реализовать функции добавить, изменить, просмотр с помощью окна – бланка.\r\n5. Реализовать функцию удалить текущую запись.\r\n6. SQL Запросы к базе данных, выбор параметров запроса:\r\na. Запрос на выборку LINQ (2-5 штуки)\r\nb. Запрос на обновление (1-2 штуки) \r\nc. Запрос на удаление (1-2 штуки)\r\n7. Исключения\r\n8. Заполненная БД 15 -20 записей");
        }

        private void Developer_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @"https://p0b0t.neocities.org", UseShellExecute = true });
        }

        private void Viewing_button_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = Bd.SelectedIndex;
            if (indexRow != -1)
            {
                var item = (Athlete)Bd.Items[indexRow];
                Data.Id = item.Id;

                Viewing viewing = new Viewing();
                viewing.ShowDialog();

                Bd.Focus();
            }
            else MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static string UpOrDel { get; set; }

        public static DataGrid Portable = new DataGrid();

        void UpAndDelShow()
        {
            Portable.ItemsSource = Bd.ItemsSource;
            UpAndDel upAndDel = new UpAndDel();
            upAndDel.ShowDialog();
            Bd.Focus();
        }

        private void Updating_Click(object sender, RoutedEventArgs e)
        {
            UpOrDel = "Up";
            UpAndDelShow();
            Bd.ItemsSource = UpAndDel.Result.ItemsSource;
            Bd.Items.Refresh();
        }

        private void Deleting_Click(object sender, RoutedEventArgs e)
        {
            UpOrDel = "Del";
            UpAndDelShow();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.ShowDialog();

            if (DataAutorization.Login == false) Close();

            if (DataAutorization.Right == "Admin") ;
            else
            {
                Managment.IsEnabled = false;
                ManagmentMenu.IsEnabled = false;
                UpAndDelete.IsEnabled = false;
            }

            Title += " " + DataAutorization.Surname + " " + DataAutorization.Name + " " + DataAutorization.Patronymic + " - " + DataAutorization.Right;
        }
    }

    public static class Data
    {
        public static int Id;
    }
}
