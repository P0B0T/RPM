using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Практическая__11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №11\nДана строка '23 2+3 2++3 2+++3 445 677'. Напишите регулярное выражение, которое найдет строки 23, 2+3, 2++3, 2+++3, не захватив остальные. Дана строка '*+ *q+ *qq+ *qqq+ *qqq qqq+'. Напишите регулярное выражение, которое найдет строки *q+, *qq+, *qqq+, не захватив остальные.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ResStroka1.Clear();
            ResStroka2.Clear();

            string s1 = String1.Text;
            Regex regex1 = new ("2[+]{0,}3");
            MatchCollection matches1 = regex1.Matches(s1);
            object[] array1 = new object[matches1.Count];
            matches1.CopyTo(array1, 0);
            for (int i = 0; i < array1.Length; i++)
            {
                ResStroka1.Text += $"{array1[i]}" + "  ";
            }

            string s2 = String2.Text;
            Regex regex2 = new ("[*]+[q]+[+]+");
            MatchCollection matches2 = regex2.Matches(s2);
            object[] array2 = new object[matches2.Count];
            matches2.CopyTo(array2, 0);
            for (int i = 0; i < array2.Length; i++)
            {
                ResStroka2.Text += $"{array2[i]}" + "  ";
            }
        }
    }
}
