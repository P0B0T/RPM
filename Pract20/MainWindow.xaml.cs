using Pract20.DataBase;
using Pract20.Pages;
using Pract20.Pages.Page2;
using Pract20.Pages.Page3;
using Pract20.Pages.Page4;
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

namespace Pract20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Frame.NavigationService.Navigate(new MainPage());
            Title = "Практическая №20" + " " + "Заказы";
        }

        private void TypesOfWork_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Frame.NavigationService.Navigate(new TypesOfWork());
            Title = "Практическая №20" + " " + "Виды работы";
        }

        private void PerformersOfWork_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Frame.NavigationService.Navigate(new PerformersOfWork());
            Title = "Практическая №20" + " " + "Исполнители работ";
        }

        private void InfoPerformers_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Frame.NavigationService.Navigate(new InformationPermormers());
            Title = "Практическая №20" + " " + "Сведения об исполнителях";
        }

        private void Sql1_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Sql.Number = 1;
            Frame.NavigationService.Navigate(new SQL());
            Title = "Практическая №20" + " " + Sql1.Header;
        }

        private void Sql2_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Sql.Number = 2;
            Frame.NavigationService.Navigate(new SQL());
            Title = "Практическая №20" + " " + Sql2.Header;
        }

        private void Sql3_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Sql.Number = 3;
            Frame.NavigationService.Navigate(new SQL());
            Title = "Практическая №20" + " " + Sql3.Header;
        }

        private void Sql4_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Sql.Number = 4;
            Frame.NavigationService.Navigate(new SQL());
            Title = "Практическая №20" + " " + Sql4.Header;
        }

        private void Sql5_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Sql.Number = 5;
            Frame.NavigationService.Navigate(new SQL());
            Title = "Практическая №20" + " " + Sql5.Header;
        }

        private void Sql6_Click(object sender, RoutedEventArgs e)
        {
            Hello.Visibility = Visibility.Hidden;
            Sql.Number = 6;
            Frame.NavigationService.Navigate(new SQL());
            Title = "Практическая №20" + " " + Sql6.Header;
        }
    }
}
