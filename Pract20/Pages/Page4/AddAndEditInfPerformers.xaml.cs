using Microsoft.EntityFrameworkCore;
using Pract20.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddAndEditInfPerformers.xaml
    /// </summary>
    public partial class AddAndEditInfPerformers : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();
        InformationAboutPerformer infPerformers = new InformationAboutPerformer();

        public AddAndEditInfPerformers()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cbInfPerformers.ItemsSource = db.DirectoryOfPerformersOfWorks.ToList();
            cbInfPerformers.DisplayMemberPath = "FullName";

            switch (AddEdit.AddOrEdit)
            {
                case "Add":
                    bAddEdit.Click += Add_Click;
                    bAddEdit.Content = "Добавить";
                    break;

                case "Edit":
                    bAddEdit.Click += Edit_Click;
                    bAddEdit.Content = "Изменить";
                    infPerformers = db.InformationAboutPerformers.Find(Data.Id);
                    tbFullName.Text = infPerformers.FullName;
                    tbDateOfBirth.Text = infPerformers.DateOfBirth.ToString();
                    tbAddress.Text = infPerformers.Address;
                    tbTelephone.Text = infPerformers.Telephone;
                    cbInfPerformers.Text = infPerformers.IdArtists.ToString();
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Check() == false) return;

            try
            {
                db.InformationAboutPerformers.Add(infPerformers);
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

            if (tbFullName.Text.Length == 0) errors.AppendLine("Введите ФИО!");
            if (!DateTime.TryParse(tbDateOfBirth.Text, out DateTime dateTime)) errors.AppendLine("Введите дату рождения!");
            if (tbAddress.Text.Length == 0) errors.AppendLine("Введите адрес!");
            if (tbTelephone.Text.Length == 0) errors.AppendLine("Введите телефон!");
            if (cbInfPerformers.SelectedItem == null) errors.AppendLine("Выберите код исполнителя из списка!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            infPerformers.FullName = tbFullName.Text;
            infPerformers.DateOfBirth = dateTime;
            infPerformers.Address = tbAddress.Text;
            infPerformers.Telephone = tbTelephone.Text;
            infPerformers.IdArtists = ((DirectoryOfPerformersOfWork)cbInfPerformers.SelectedItem).IdArtists;

            return true;
        }

        private void AddExt_Click(object sender, RoutedEventArgs e)
        {
            BufferData.CorrectPage = "PerformersOfWork";

            AddAndEditWindow addAndEdit = new AddAndEditWindow();
            addAndEdit.ShowDialog();
        }
    }
}
