using Pract18.DataBase;
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

namespace Pract18.FunctionalWindows
{
    /// <summary>
    /// Логика взаимодействия для Viewing.xaml
    /// </summary>
    public partial class Viewing : Window
    {
        SportsVeteransGetContext db = SportsVeteransGetContext.GetContext();
        Athlete athlet = new Athlete();

        public Viewing()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            athlet = db.Athletes.Find(Data.Id);
            Hotel_TextBox.Text = athlet.Hotel;
            RoomNumber_TextBox.Text = athlet.RoomNumber.ToString();
            NumberOfSeats_TextBox.Text = athlet.NumberOfSeats.ToString();
            AthleteSFullName_TextBox.Text = athlet.AthleteSFullName;
            AgeGroup_TextBox.Text = athlet.AgeGroup;
            City_TextBox.Text = athlet.City;
            SportTipe_TextBox.Text = athlet.SportTipe;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
