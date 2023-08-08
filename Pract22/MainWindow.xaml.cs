using Microsoft.EntityFrameworkCore;
using Pract22.Database;
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
using static Pract22.Buffer;

namespace Pract22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ИнформацияОСтранахGetContext db = ИнформацияОСтранахGetContext.GetContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Страны.Load();

            Countries.ItemsSource = db.Страны.Local.ToBindingList();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (SearchМатерик.Text.Length == 0 && SearchНазвание.Text.Length == 0)
            {
                MessageBox.Show("Введите параметры поиска!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (SearchМатерик.Text.Length == 0)
            {
                foreach (var item in Countries.Items)
                {
                    if (((Страны)item).Название.Contains(SearchНазвание.Text))
                    {
                        Countries.SelectedItem = item;
                        Countries.ScrollIntoView(item);
                        break;
                    }
                }
            }

            if (SearchНазвание.Text.Length == 0)
            {
                foreach (var item in Countries.Items)
                {
                    if (((Страны)item).Материк.Contains(SearchМатерик.Text))
                    {
                        Countries.SelectedItem = item;
                        Countries.ScrollIntoView(item);
                        break;
                    }
                }
            }

            foreach (var item in Countries.Items)
            {
                if (((Страны)item).Материк.Contains(SearchМатерик.Text) && ((Страны)item).Название.Contains(SearchНазвание.Text))
                {
                    Countries.SelectedItem = item;
                    Countries.ScrollIntoView(item);
                    break;
                }
            }
        }

        private void Origin_Click(object sender, RoutedEventArgs e)
        {
            Countries.ItemsSource = db.Страны.Local.ToBindingList();
        }

        private void bFilter_Click(object sender, RoutedEventArgs e)
        {
            if (tbFilter.Text.Length == 0)
            {
                MessageBox.Show("Введите параметры фильтрации!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var countries = db.Страны.ToList();

            Countries.ItemsSource = countries.Where(c => c.МатерикCheck.ToLower().Contains(tbFilter.Text.ToLower()));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddOrEdit.Or = "Add";

            AddAndEdit addAndEdit = new AddAndEdit();
            addAndEdit.ShowDialog();

            Countries.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddOrEdit.Or = "Edit";

            int indexRow = Countries.SelectedIndex;
            if (indexRow != -1)
            {
                var item = (Страны)Countries.Items[indexRow];
                Data.Id = item.Код;

                AddAndEdit addAndEdit = new AddAndEdit();
                addAndEdit.ShowDialog();

                Countries.Items.Refresh();
                Countries.Focus();
            }
            else MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);

            int indexRow = Countries.SelectedIndex;

            if (result == MessageBoxResult.Yes)
            {
                if (indexRow != -1)
                {
                    var item = (Страны)Countries.Items[indexRow];
                    db.Страны.Remove(item);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Выберите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Enter();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Enter();
        }

        void Enter()
        {
            Autorization autorization = new Autorization();
            autorization.ShowDialog();

            if (DataAutorization.Login == false) Close();

            if (DataAutorization.Right == "Admin") Managment.IsEnabled = true;
            else
            {
                Managment.IsEnabled = false;
            }

            Title += " " + DataAutorization.Surname + " " + DataAutorization.Name + " " + DataAutorization.Patronymic + " - " + DataAutorization.Right;
        }
    }
}
