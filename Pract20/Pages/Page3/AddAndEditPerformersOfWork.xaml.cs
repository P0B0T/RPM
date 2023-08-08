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
    /// Логика взаимодействия для AddAndEditPerformersOfWork.xaml
    /// </summary>
    public partial class AddAndEditPerformersOfWork : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();
        DirectoryOfPerformersOfWork performersOfWork = new DirectoryOfPerformersOfWork();

        public AddAndEditPerformersOfWork()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            switch (AddEdit.AddOrEdit)
            {
                case "Add":
                    bAddEdit.Click += Add_Click;
                    bAddEdit.Content = "Добавить";
                    break;

                case "Edit":
                    bAddEdit.Click += Edit_Click;
                    bAddEdit.Content = "Изменить";
                    performersOfWork = db.DirectoryOfPerformersOfWorks.Find(Data.Id);
                    tbFullName.Text = performersOfWork.FullName;
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Check() == false) return;

            try
            {
                db.DirectoryOfPerformersOfWorks.Add(performersOfWork);
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
            if (tbFullName.Text.Length == 0)
            {
                MessageBox.Show("Введите ФИО!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            performersOfWork.FullName = tbFullName.Text;

            return true;
        }
    }
}
