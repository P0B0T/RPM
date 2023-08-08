using Microsoft.EntityFrameworkCore;
using Pract18.DataBase;
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
using System.Windows.Shapes;

namespace Pract18.FunctionalWindows
{
    /// <summary>
    /// Логика взаимодействия для UpAndDel.xaml
    /// </summary>
    public partial class UpAndDel : Window
    {
        SportsVeteransGetContext db = SportsVeteransGetContext.GetContext();

        public UpAndDel()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (MainWindow.UpOrDel)
            {
                case "Up":
                    Updating.Visibility = Visibility.Visible;
                    break;
                case "Del":
                    Deleting.Visibility = Visibility.Visible;
                    break;
            }
        }

        public static DataGrid Result = new DataGrid();

        private void UpNumberOfSeats_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RoomNumber_TextBox.Text, out int roomNumber))
            {
                MessageBox.Show("Введите номер комнаты! (цифрой)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                RoomNumber_TextBox.Focus();
                return;
            }
            if (!int.TryParse(NumberOfSeats_TextBox.Text, out int numberOfSeats))
            {
                MessageBox.Show("Введите количество мест!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                NumberOfSeats_TextBox.Focus();
                return;
            }

            try
            {
                db.Athletes.FromSqlRaw($"UPDATE Athletes SET [Number of seats] = {numberOfSeats} WHERE [Room number] = {roomNumber} ").ToList();
            }
            catch
            {
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                Result.ItemsSource = db.Athletes.Local.ToBindingList();
            }

            Close();
        }

        private void UpAgeGroup_Click(object sender, RoutedEventArgs e)
        {
            if (AthleteSFullName_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Введите ФИО спортсмена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                AthleteSFullName_TextBox.Focus();
                return;
            }
            if (AgeGroup_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Введите возрастную группу спортсмена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                AthleteSFullName_TextBox.Focus();
                return;
            }

            try
            {
                db.Athletes.FromSqlRaw("UPDATE Athletes SET [Age group] = '" + AgeGroup_TextBox.Text + "' WHERE [Athlete's full name] = '" + AthleteSFullName_TextBox.Text +"'").ToList();
            }
            catch
            {
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                Result.ItemsSource = db.Athletes.Local.ToBindingList();
            }

            Close();
        }

        private void DeleteCity_Click(object sender, RoutedEventArgs e)
        {
            if (City_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Введите город!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                City_TextBox.Focus();
                return;
            }

            try
            {
                db.Athletes.FromSqlRaw("DELETE Athletes WHERE City = '" + City_TextBox.Text + "'").ToList();
            }
            catch
            {
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                Result.ItemsSource = db.Athletes.Local.ToBindingList();
            }

            Close();
        }

        private void DeleteSportTipe_Click(object sender, RoutedEventArgs e)
        {
            if (SportTipe_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Введите вид спорта!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                SportTipe_TextBox.Focus();
                return;
            }

            try
            {
                db.Athletes.FromSqlRaw("DELETE Athletes WHERE [Sport tipe] = '" + SportTipe_TextBox.Text + "'").ToList();
            }
            catch
            {
                db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                Result.ItemsSource = db.Athletes.Local.ToBindingList();
            }

            Close();
        }
    }
}
