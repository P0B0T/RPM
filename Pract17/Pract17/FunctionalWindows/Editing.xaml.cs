using Pract17.Database;
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
using System.Windows.Shapes;

namespace Pract17.FunctionalWindows
{
    /// <summary>
    /// Логика взаимодействия для Editing.xaml
    /// </summary>
    public partial class Editing : Window
    {
        DataBaseContext db = DataBaseContext.GetContext();
        Участники participant = new Участники();

        public Editing()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            participant = db.Участники.Find(Data.Id);
            ФИО_TextBox.Text = participant.ФИО;
            Город_TextBox.Text = participant.Город;
            ФамилияТренера_TextBox.Text = participant.Фамилия_тренера;
            Оценка_TextBox.Text = participant.Оценка.ToString();
        }

        private void Change_button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (ФИО_TextBox.Text.Length == 0) errors.AppendLine("Введите фио!");
            if (Город_TextBox.Text.Length == 0) errors.AppendLine("Введите город!");
            if (ФамилияТренера_TextBox.Text.Length == 0) errors.AppendLine("Введите фамилию тренера!");
            if (!int.TryParse(Оценка_TextBox.Text, out int estimation)) errors.AppendLine("Введите число!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            participant.ФИО = ФИО_TextBox.Text;
            participant.Город = Город_TextBox.Text;
            participant.Фамилия_тренера = ФамилияТренера_TextBox.Text;
            participant.Оценка = estimation;

            try
            {
                db.SaveChanges();
                Close();
            }
            catch { }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
