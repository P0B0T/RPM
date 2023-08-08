using Pract20.DataBase;
using Pract20.Pages.Page1;
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
using System.Windows.Shapes;

namespace Pract20
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditWindow.xaml
    /// </summary>
    public partial class AddAndEditWindow : Window
    {
        public AddAndEditWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (BufferData.CorrectPage)
            {
                case "TypeOfWork":
                    gTable2.Visibility = Visibility.Visible;
                    Table2.NavigationService.Navigate(new AddAndEditTypesOfWork());
                    break;

                case "PerformersOfWork":
                    gTable2.Visibility = Visibility.Visible;
                    Table2.NavigationService.Navigate(new AddAndEditPerformersOfWork());
                    break;

                case "InfOfPerformers":
                    gTable2.Visibility = Visibility.Visible;
                    Table2.NavigationService.Navigate(new AddAndEditInfPerformers());
                    break;

                case "Orders":
                    gTable2.Visibility = Visibility.Visible;
                    Table2.NavigationService.Navigate(new AddAndEditOrders());
                    break;

                case "OrdersExt":
                    gTable1.Visibility = Visibility.Visible;
                    gTable2.Visibility = Visibility.Visible;

                    gTable2.Margin = new Thickness(270, 0, 0, 0);

                    Table1.NavigationService.Navigate(new AddAndEditTypesOfWork());
                    Table2.NavigationService.Navigate(new AddAndEditPerformersOfWork());
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
