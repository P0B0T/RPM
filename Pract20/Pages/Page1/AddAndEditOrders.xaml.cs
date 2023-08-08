using Pract20.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
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

namespace Pract20.Pages.Page1
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditOrders.xaml
    /// </summary>
    public partial class AddAndEditOrders : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();
        Orders orders = new Orders();

        public AddAndEditOrders()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cbPerformersOfWork.ItemsSource = db.DirectoryOfPerformersOfWorks.ToList();
            cbPerformersOfWork.DisplayMemberPath = "FullName";

            cbTypesOfWork.ItemsSource = db.DirectoryOfTypesOfWorks.ToList();
            cbTypesOfWork.DisplayMemberPath = "NameOfTheWork";

            switch (AddEdit.AddOrEdit)
            {
                case "Add":
                    bAddEdit.Click += Add_Click;
                    bAddEdit.Content = "Добавить";
                    break;

                case "Edit":
                    bAddEdit.Click += Edit_Click;
                    bAddEdit.Content = "Изменить";
                    orders = db.Orders.Find(Data.Id);
                    tbDate.Text = orders.Date.ToString();
                    tbClient.Text = orders.Client;
                    tbCarBrand.Text = orders.CarBrand;
                    cbTypesOfWork.Text = orders.IdOfTheTypeOfWork.ToString();
                    cbPerformersOfWork.Text = orders.IdArtists.ToString();
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Check() == false) return;

            try
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                MessageBox.Show("Запись добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch { }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Check() == false) return;

            try
            {
                db.SaveChanges();
                MessageBox.Show("Запись изменена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch { }
        }

        bool Check()
        {
            StringBuilder errors = new StringBuilder();

            if (!DateTime.TryParse(tbDate.Text, out DateTime date)) errors.AppendLine("Введите дату!");
            if (tbClient.Text.Length == 0) errors.AppendLine("Введите клиента!");
            if (tbCarBrand.Text.Length == 0) errors.AppendLine("Введите марку машины!");
            if (cbTypesOfWork.SelectedItem == null) errors.AppendLine("Выберите код работы из списка!");
            if (cbPerformersOfWork.SelectedItem == null) errors.AppendLine("Выберите код исполнителя из списка!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            orders.Date = date;
            orders.Client = tbClient.Text;
            orders.CarBrand = tbCarBrand.Text;
            orders.IdOfTheTypeOfWork = ((DirectoryOfTypesOfWork)cbTypesOfWork.SelectedItem).IdWork;
            orders.IdArtists = ((DirectoryOfPerformersOfWork)cbPerformersOfWork.SelectedItem).IdArtists;

            return true;
        }

        private void AddExt_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "OrdersExt";

            AddAndEditWindow addAndEdit = new AddAndEditWindow();
            addAndEdit.ShowDialog();
        }
    }
}
