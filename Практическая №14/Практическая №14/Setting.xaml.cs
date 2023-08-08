using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
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
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Rows.Text, out int rows))
            {
                MessageBox.Show("Введите числовое значение");
                Rows.Clear();
            }
            if (!int.TryParse(Columns.Text, out int columns))
            {
                MessageBox.Show("Введите числовое значение");
                Columns.Clear();
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("config.ini"))
                {
                    writer.WriteLine(rows);
                    writer.WriteLine(columns);
                    Close();
                }
            }
        }
    }
}
