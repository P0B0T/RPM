using Microsoft.Win32;
using Pract22.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using static Pract22.Buffer;
using static System.Net.Mime.MediaTypeNames;

namespace Pract22
{
    /// <summary>
    /// Логика взаимодействия для AddAndEdit.xaml
    /// </summary>
    public partial class AddAndEdit : Window
    {
        ИнформацияОСтранахGetContext db = ИнформацияОСтранахGetContext.GetContext();
        Страны countries = new Страны();
        OpenFileDialog open = new OpenFileDialog();

        public AddAndEdit()
        {
            InitializeComponent();
            Height += 25;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (AddOrEdit.Or)
            {
                case "Add":
                    bAddOrEdit.Click += Add_Click;
                    bAddOrEdit.Content = "Добавить";
                    break;

                case "Edit":
                    bAddOrEdit.Click += Edit_Click;
                    bAddOrEdit.Content = "Редактировать";

                    countries = db.Страны.Find(Data.Id);
                    Name.Text = countries.Название;
                    Mainland.Text = countries.Материк;
                    Capital.Text = countries.Столица;
                    CountPeoples.Text = countries.КоличествоЖителей.ToString();

                    if (countries.ФотоСтраны != null)
                    {
                        BitmapImage photo = new BitmapImage(new Uri(countries.ФотоСтраныJPG));
                        PhotoCountry.Source = photo;
                    }

                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Check() == false) return;

            try
            {
                db.Страны.Add(countries);
                db.SaveChanges();
                MessageBox.Show("Запись добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
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
                Close();
            }
            catch { }
        }

        bool Check()
        {
            StringBuilder errors = new StringBuilder();

            if (Name.Text.Length == 0) errors.AppendLine("Введите название!");
            if (!int.TryParse(CountPeoples.Text, out int count)) errors.AppendLine("Введите количество жителей!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            countries.Название = Name.Text;
            countries.Материк = Mainland.Text;
            countries.Столица = Capital.Text;
            countries.КоличествоЖителей = count;

            if (open.SafeFileName.Length != 0)
            {
                BitmapImage photo = new BitmapImage(new Uri(open.FileName));
                countries.ФотоСтраны = open.SafeFileName;
            }

            return true;
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            open.Filter = "Все файлы |*.*| Файлы *.jpg|*.jpg";
            open.FilterIndex = 2;
            if (open.ShowDialog() == true)
            {
                BitmapImage photo = new BitmapImage(new Uri(open.FileName));
                PhotoCountry.Source = photo;
            }
        }
    }
}
