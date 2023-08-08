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
    /// Логика взаимодействия для AddAndEditTypesOfWork.xaml
    /// </summary>
    public partial class AddAndEditTypesOfWork : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();
        DirectoryOfTypesOfWork typeOfWork = new DirectoryOfTypesOfWork();

        public AddAndEditTypesOfWork()
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
                    typeOfWork = db.DirectoryOfTypesOfWorks.Find(Data.Id);
                    tbCarBrand.Text = typeOfWork.CarBrand;
                    tbNameOfTheWork.Text = typeOfWork.NameOfTheWork;
                    tbCostOfWork.Text = typeOfWork.CostOfWork.ToString();
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Check() == false) return;

            try
            {
                db.DirectoryOfTypesOfWorks.Add(typeOfWork);
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

            if (tbCarBrand.Text.Length == 0) errors.AppendLine("Введите марку автомобиля!");
            if (tbNameOfTheWork.Text.Length == 0) errors.AppendLine("Введите наименование работы!");
            if (!decimal.TryParse(tbCostOfWork.Text, out decimal costOfWork)) errors.AppendLine("Введите стоимость работы!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            typeOfWork.CarBrand = tbCarBrand.Text;
            typeOfWork.NameOfTheWork = tbNameOfTheWork.Text;
            typeOfWork.CostOfWork = costOfWork;

            return true;
        }
    }
}
