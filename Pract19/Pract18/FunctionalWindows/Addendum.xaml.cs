﻿using Pract18.DataBase;
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
    /// Логика взаимодействия для Addendum.xaml
    /// </summary>
    public partial class Addendum : Window
    {
        SportsVeteransGetContext db = SportsVeteransGetContext.GetContext();
        Athlete athlet = new Athlete();

        public Addendum()
        {
            InitializeComponent();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (Hotel_TextBox.Text.Length == 0) errors.AppendLine("Введите название гостиницы!");
            if (!int.TryParse(RoomNumber_TextBox.Text, out int roomNumber)) errors.AppendLine("Введите номер комнаты!");
            if (!int.TryParse(NumberOfSeats_TextBox.Text, out int numberOfSeats)) errors.AppendLine("Введите количество мест в комнате!");
            if (AthleteSFullName_TextBox.Text.Length == 0) errors.AppendLine("Введите ФИО спортсмена!");
            if (AgeGroup_TextBox.Text.Length == 0) errors.AppendLine("Введите возрастную группу спортсмена!");
            if (City_TextBox.Text.Length == 0) errors.AppendLine("Введите город!");
            if (SportTipe_TextBox.Text.Length == 0) errors.AppendLine("Введите вид спорта!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            athlet.Hotel = Hotel_TextBox.Text;
            athlet.RoomNumber = roomNumber;
            athlet.NumberOfSeats = numberOfSeats;
            athlet.AthleteSFullName = AthleteSFullName_TextBox.Text;
            athlet.AgeGroup = AgeGroup_TextBox.Text;
            athlet.City = City_TextBox.Text;
            athlet.SportTipe = SportTipe_TextBox.Text;

            try
            {
                db.Athletes.Add(athlet);
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
