using Microsoft.EntityFrameworkCore;
using Pract20.DataBase;
using Pract20.Pages.Page3;
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

namespace Pract20.Pages.Page4
{
    /// <summary>
    /// Логика взаимодействия для InformationPermormers.xaml
    /// </summary>
    public partial class InformationPermormers : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();

        public InformationPermormers()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.InformationAboutPerformers.Load();
            db.DirectoryOfPerformersOfWorks.Load();

            dgInformationPerformers.ItemsSource = db.InformationAboutPerformers.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "InfOfPerformers";
            AddEdit.AddOrEdit = "Add";

            AddAndEditWindow addAndEdit = new AddAndEditWindow();
            addAndEdit.ShowDialog();

            dgInformationPerformers.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "InfOfPerformers";
            AddEdit.AddOrEdit = "Edit";

            int indexRow = dgInformationPerformers.SelectedIndex;
            if (indexRow != -1)
            {
                var item = (InformationAboutPerformer)dgInformationPerformers.Items[indexRow];
                Data.Id = item.Id;

                AddAndEditWindow addAndEdit = new AddAndEditWindow();
                addAndEdit.ShowDialog();

                dgInformationPerformers.Items.Refresh();
                dgInformationPerformers.Focus();
            }
            else MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
            int indexRow = dgInformationPerformers.SelectedIndex;
            if (result == MessageBoxResult.Yes)
            {
                if (indexRow != -1)
                {
                    var item = (InformationAboutPerformer)dgInformationPerformers.Items[indexRow];
                    db.InformationAboutPerformers.Remove(item);
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
