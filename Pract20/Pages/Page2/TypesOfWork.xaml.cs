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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract20.Pages.Page2
{
    /// <summary>
    /// Логика взаимодействия для TypesOfWork.xaml
    /// </summary>
    public partial class TypesOfWork : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();

        public TypesOfWork()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.DirectoryOfTypesOfWorks.Load();

            dgTypesOfWork.ItemsSource = db.DirectoryOfTypesOfWorks.Local.ToBindingList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
            int indexRow = dgTypesOfWork.SelectedIndex;
            if (result == MessageBoxResult.Yes)
            {
                if (indexRow != -1)
                {
                    var item = (DirectoryOfTypesOfWork)dgTypesOfWork.Items[indexRow];
                    db.DirectoryOfTypesOfWorks.Remove(item);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "TypeOfWork";
            AddEdit.AddOrEdit = "Add";

            AddAndEditWindow addAndEdit = new AddAndEditWindow();
            addAndEdit.ShowDialog();

            dgTypesOfWork.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "TypeOfWork";
            AddEdit.AddOrEdit = "Edit";

            int indexRow = dgTypesOfWork.SelectedIndex;
            if (indexRow != -1)
            {
                var item = (DirectoryOfTypesOfWork)dgTypesOfWork.Items[indexRow];
                Data.Id = item.IdWork;

                AddAndEditWindow addAndEdit = new AddAndEditWindow();
                addAndEdit.ShowDialog();

                dgTypesOfWork.Items.Refresh();
                dgTypesOfWork.Focus();
            }
            else MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
