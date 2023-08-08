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

namespace Практичекая__8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Father father = new Father(default, default);
        Child child = new Child(default, default, default);
        public MainWindow()
        {
            InitializeComponent();
        }
        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №8\nСоздать интерфейс - человек, у которого есть имя, функция печати. Создать класс отец, у которого функция печати выводит имя. Создать класс ребенок, у которого есть отец, отчество, функция печати выводит имя и отчество. Классы должны включать конструкторы. Сравнение производить по фамилии.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Input_Father_Data_Click(object sender, RoutedEventArgs e)
        {
            father = new Father(Father_Name.Text, Father_Surname.Text);
            MessageBox.Show("Данные успешно введены");
        }

        private void Output_Father_Data_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(father.Print());
        }

        private void Input_Child_Data_Click(object sender, RoutedEventArgs e)
        {
            child = new Child(Child_Name.Text, Child_Surname.Text, Child_Patronymic.Text);
            MessageBox.Show("Данные успешно введены");
        }

        private void Output_Child_Data_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(child.Print());
        }

        private void Delete_Data_Father_Click(object sender, RoutedEventArgs e)
        {
            Father_Name.Clear();
            Father_Surname.Clear();
            father = new Father(default, default);
        }

        private void Delete_Data_Child_Click(object sender, RoutedEventArgs e)
        {
            Child_Name.Clear();
            Child_Surname.Clear();
            Child_Patronymic.Clear();
            child = new Child(default, default, default);
        }

        private void Comparison_Click(object sender, RoutedEventArgs e)
        {
            Child father1 = new Child(Father_Name.Text, Father_Surname.Text, default);
            int comparison = child.CompareTo(father1);
            if (comparison == 1) MessageBox.Show("Фамилии совпадают");
            if (comparison == -1) MessageBox.Show("Фамилии не совпадают");
        }
    }
}
