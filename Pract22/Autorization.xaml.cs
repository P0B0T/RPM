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
using static Pract22.Buffer;
using System.Windows.Threading;
using Pract22.Database;
using Microsoft.EntityFrameworkCore;

namespace Pract22
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        DispatcherTimer timer;
        int countLogin = 1;
        ИнформацияОСтранахGetContext db = ИнформацияОСтранахGetContext.GetContext();

        public Autorization()
        {
            InitializeComponent();
        }

        void GetCapcha()
        {
            string arrayChar = "QWERTYUIOPLKJHGFDSAZXCVBNMmnbvcxzasdfghjklpoiuytrewq1234567890";
            string capcha = null;

            Random random = new Random();

            for (int i = 1; i <= 4; i++)
            {
                capcha = capcha + arrayChar[random.Next(0, arrayChar.Length)];
            }

            Grid.Visibility = Visibility.Visible;
            Capcha.Text = capcha;
            InputCapcha.Clear();
            Capcha.LayoutTransform = new RotateTransform(random.Next(-15, 15));
            Line.X1 = 10;
            Line.Y1 = random.Next(10, 40);
            Line.X2 = 280;
            Line.Y2 = random.Next(10, 40);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            db.Role.Load();

            Login.Focus();
            DataAutorization.Login = false;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            StackPanel.IsEnabled = true;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var user = db.User.Where(p => p.Login == Login.Text && p.Password == Password.Password);

            if (user.Count() == 1 && Capcha.Text == InputCapcha.Text)
            {
                DataAutorization.Login = true;
                DataAutorization.Surname = user.First().Surname;
                DataAutorization.Name = user.First().Name;
                DataAutorization.Patronymic = user.First().Patronymic;
                DataAutorization.Right = user.First().RoleNavigation.Name;
                Close();
            }
            else
            {
                if (user.Count() == 1)
                {
                    MessageBox.Show("Капча неверна! Повторите ввод.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Логин, пароль неверны! Повторите ввод.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                GetCapcha();

                if (countLogin >= 2)
                {
                    StackPanel.IsEnabled = false;
                    timer.Start();
                }

                countLogin++;
                Login.Focus();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            DataAutorization.Login = true;
            DataAutorization.Surname = "Гость";
            DataAutorization.Name = null;
            DataAutorization.Patronymic = null;
            DataAutorization.Right = "Клиент";
            Close();
        }
    }
}
