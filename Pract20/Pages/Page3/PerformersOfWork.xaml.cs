using Microsoft.EntityFrameworkCore;
using Pract20.DataBase;
using Pract20.Pages.Page2;
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

namespace Pract20.Pages.Page3
{
    /// <summary>
    /// Логика взаимодействия для PerformersOfWork.xaml
    /// </summary>
    public partial class PerformersOfWork : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();

        public PerformersOfWork()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.DirectoryOfPerformersOfWorks.Load();

            dgPerformersOfWork.ItemsSource = db.DirectoryOfPerformersOfWorks.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "PerformersOfWork";
            AddEdit.AddOrEdit = "Add";

            AddAndEditWindow addAndEdit = new AddAndEditWindow();
            addAndEdit.ShowDialog();

            dgPerformersOfWork.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "PerformersOfWork";
            AddEdit.AddOrEdit = "Edit";

            int indexRow = dgPerformersOfWork.SelectedIndex;
            if (indexRow != -1)
            {
                var item = (DirectoryOfPerformersOfWork)dgPerformersOfWork.Items[indexRow];
                Data.Id = item.IdArtists;

                AddAndEditWindow addAndEdit = new AddAndEditWindow();
                addAndEdit.ShowDialog();

                dgPerformersOfWork.Items.Refresh();
                dgPerformersOfWork.Focus();
            }
            else MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
            int indexRow = dgPerformersOfWork.SelectedIndex;
            if (result == MessageBoxResult.Yes)
            {
                if (indexRow != -1)
                {
                    var item = (DirectoryOfPerformersOfWork)dgPerformersOfWork.Items[indexRow];
                    db.DirectoryOfPerformersOfWorks.Remove(item);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
