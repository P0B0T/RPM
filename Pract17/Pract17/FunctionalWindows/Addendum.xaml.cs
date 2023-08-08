using Pract17.Database;
using System.Text;
using System.Windows;

namespace Pract17.FunctionalWindows
{
    /// <summary>
    /// Логика взаимодействия для Addendum.xaml
    /// </summary>
    public partial class Addendum : Window
    {
        DataBaseContext db = DataBaseContext.GetContext();
        Участники participant = new Участники();

        public Addendum()
        {
            InitializeComponent();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
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
                db.Участники.Add(participant);
                db.SaveChanges();
                Close();
            }
            catch  { }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
