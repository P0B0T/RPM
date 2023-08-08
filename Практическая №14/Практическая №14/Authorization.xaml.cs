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

namespace Практическая__14
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Window_Activate(object sender, EventArgs e)
        {
            Pas.Focus();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Pas.Password == "123") Close();
            else
            {
                MessageBox.Show("Пароль неверен. Повторите ввод.");
                Pas.Focus();
            }
        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }
    }
}
