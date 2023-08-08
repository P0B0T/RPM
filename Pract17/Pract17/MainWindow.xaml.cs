using Microsoft.EntityFrameworkCore;
using Pract17.Database;
using Pract17.FunctionalWindows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Pract17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        DataBaseContext db = DataBaseContext.GetContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Участники.Load();

            Bd.ItemsSource = db.Участники.Local.ToBindingList();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            Addendum addendum = new Addendum();
            addendum.ShowDialog();
            Bd.Focus();
        }

        private void Change_button_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = Bd.SelectedIndex;
            if (indexRow != -1)
            {
                var item = (Участники)Bd.Items[indexRow];
                Data.Id = item.Id;

                Editing editing = new Editing();
                editing.ShowDialog();

                Bd.Items.Refresh();
                Bd.Focus();
            }
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = Bd.SelectedIndex;
            if(indexRow != -1)
            {
                var item = (Участники)Bd.Items[indexRow];
                db.Участники.Remove(item);
                db.SaveChanges();
            }
        }

        private void Search_button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Bd.Items.Count; i++)
            {
                var row = (Участники)Bd.Items[i];
                string findContent = row.ФИО;

                try
                {
                    if (findContent != null && findContent.Contains(Search_TextBox.Text))
                    {
                        object item = Bd.Items[i];
                        Bd.SelectedItem = item;
                        Bd.ScrollIntoView(item);
                        Bd.Focus();
                        break;
                    }
                }
                catch { }
            }
        }

        List<Участники> list;

        private void Filter_button_Click(object sender, RoutedEventArgs e)
        {
            list = db.Участники.ToList();

            var filtered = list.Where(list => list.ФИО.Contains(Filter_TextBox.Text));

            Bd.ItemsSource = filtered;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. Разработать интерфейс для доступа и управления однотабличной базой данных. \r\n2. Создать меню.\r\n3. Реализовать кнопки для функций Добавить, Редактировать, Удалить.\r\n4. Реализовать функции Добавить, Изменить с помощью окна – бланка.\r\n5. Реализовать функцию поиск и замена информации.\r\n6. Реализовать фильтр.\r\n7. Использовать исключения.\r\n");
        }

        private void Developer_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = @"https://p0b0t.neocities.org", UseShellExecute = true });
        }

        private void Origin_button_Click(object sender, RoutedEventArgs e)
        {
            Bd.ItemsSource = db.Участники.Local.ToBindingList();
        }
    }

    public static class Data
    {
        public static int Id;
    }
}
