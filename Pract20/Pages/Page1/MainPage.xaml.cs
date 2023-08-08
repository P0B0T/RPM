using Microsoft.EntityFrameworkCore;
using Pract20.DataBase;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract20.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.Orders.Load();
            db.DirectoryOfTypesOfWorks.Load();
            db.DirectoryOfPerformersOfWorks.Load();

            dgOrders.ItemsSource = db.Orders.Local.ToBindingList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(txtboxSearch.Text, out int id))
            {
                MessageBox.Show("Некооректный ввод", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txtboxSearch.Focus();
                return;
            }

            for (int i = 0; i < dgOrders.Items.Count; i++)
            {
                var row = (Orders)dgOrders.Items[i];
                string findContent = row.OrderNumber.ToString();

                try
                {
                    if (findContent != null && findContent.Contains(txtboxSearch.Text))
                    {
                        object item = dgOrders.Items[i];
                        dgOrders.SelectedItem = item;
                        dgOrders.ScrollIntoView(item);
                        dgOrders.Focus();
                        break;
                    }

                    if (!findContent.Contains(txtboxSearch.Text) && i == dgOrders.Items.Count - 1)
                    {
                        MessageBox.Show("Этого кода нет в базе данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtboxSearch.Clear();
                        txtboxSearch.Focus();
                        break;
                    }
                }
                catch { }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
            int indexRow = dgOrders.SelectedIndex;
            if (result == MessageBoxResult.Yes)
            {
                if (indexRow != -1)
                {
                    var item = (Orders)dgOrders.Items[indexRow];
                    db.Orders.Remove(item);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "Orders";
            AddEdit.AddOrEdit = "Edit";

            int indexRow = dgOrders.SelectedIndex;
            if (indexRow != -1)
            {
                var item = (Orders)dgOrders.Items[indexRow];
                Data.Id = item.OrderNumber;

                AddAndEditWindow addAndEdit = new AddAndEditWindow();
                addAndEdit.ShowDialog();

                dgOrders.Items.Refresh();
                dgOrders.Focus();
            }
            else MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "Orders";
            AddEdit.AddOrEdit = "Add";

            AddAndEditWindow addAndEdit = new AddAndEditWindow();
            addAndEdit.ShowDialog();

            dgOrders.Focus();
        }
    }
}
