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
    /// Логика взаимодействия для Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        SportsVeteransGetContext db = SportsVeteransGetContext.GetContext();

        public Filter()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (MainWindow.FilterType)
            {
                case "Hotel":
                    FilterHotel_StackPanel.Visibility = Visibility.Visible;
                    break;
                case "RoomNumber":
                    FilterRoomNumber_StackPanel.Visibility = Visibility.Visible;
                    break;
                case "AgeGroup":
                    FilterAgeGroup_StackPanel.Visibility = Visibility.Visible;
                    break;
                case "City":
                    FilterCity_StackPanel.Visibility = Visibility.Visible;
                    break;
                case "SportTipe":
                    FilterSportTipe_StackPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        public static DataGrid Result = new DataGrid();

        private void FilterHotel_Click(object sender, RoutedEventArgs e)
        {
            if (InputHotel.Text.Length == 0)
            {
                MessageBox.Show("Введите название гостиницы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                InputHotel.Focus();
                return;
            }

            var filteredHotel = db.Athletes.Where(a => a.Hotel == InputHotel.Text);

            Result.ItemsSource = filteredHotel.ToList();

            Close();
        }

        private void FilterRoomNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(InputRoomNumber.Text, out int roomNumber))
            {
                MessageBox.Show("Введите номер комнаты (цифрами)!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                InputHotel.Focus();
                return;
            }

            var filteredRoomNumber = db.Athletes.Where(a => a.RoomNumber == roomNumber);

            Result.ItemsSource = filteredRoomNumber.ToList();

            Close();
        }

        private void FilterAgeGroup_Click(object sender, RoutedEventArgs e)
        {
            if (InputAgeGroup.Text.Length == 0)
            {
                MessageBox.Show("Введите возрастную группу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                InputHotel.Focus();
                return;
            }

            var filteredHotel = db.Athletes.Where(a => a.AgeGroup == InputAgeGroup.Text);

            Result.ItemsSource = filteredHotel.ToList();

            Close();
        }

        private void FilterCity_Click(object sender, RoutedEventArgs e)
        {
            if (InputCity.Text.Length == 0)
            {
                MessageBox.Show("Введите город!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                InputHotel.Focus();
                return;
            }

            var filteredHotel = db.Athletes.Where(a => a.City == InputCity.Text);

            Result.ItemsSource = filteredHotel.ToList();

            Close();
        }

        private void FilterSportTipe_Click(object sender, RoutedEventArgs e)
        {
            if (InputSportTipe.Text.Length == 0)
            {
                MessageBox.Show("Введите вид спорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                InputHotel.Focus();
                return;
            }

            var filteredHotel = db.Athletes.Where(a => a.SportTipe == InputSportTipe.Text);

            Result.ItemsSource = filteredHotel.ToList();

            Close();
        }
    }
}
