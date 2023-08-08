using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Практическая__9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaggageInformation baggage;

        int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_programm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Касаткин Олег Андреевич ИСП-31\nПрактическая №9\nБагаж пассажира характеризуется количеством вещей и общим весом вещей. Сведения о багаже каждого пассажира представляют собой структуру с двумя полями: одно поле целого типа (количество вещей) и одно - действительное (вес в килограммах). Вывести результат на экран.Найти багаж, средний вес одной вещи в котором отличается не более, чем на 0.3 кг от общего среднего веса одной вещи.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void Check()
        {
            try
            {
                int numbers_of_items = Convert.ToInt32(Numbers_of_items.Text);
                double weight_in_kilograms = Convert.ToDouble(Weight_in_kilograms.Text);

                baggage.Numbers_of_items = numbers_of_items;
                baggage.Weight_in_kilograms = weight_in_kilograms;
            }
            catch(Exception)
            {
                MessageBox.Show("Данные введены неверно");
                Numbers_of_items.Clear();
                Weight_in_kilograms.Clear();
            }
        }

        private void Clear_local()
        {
            Numbers_of_items.Clear();
            Weight_in_kilograms.Clear();
            Result.Clear();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            Check();
            DataGrid.Items.Add(new BaggageInformation {Numbers_of_items = baggage.Numbers_of_items, Weight_in_kilograms = baggage.Weight_in_kilograms});
            count++;
            Clear_local();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.Items.Clear();
            Clear_local();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if(DataGrid.Items.Count == 0)
            {
                MessageBox.Show("Заполните таблицу");
                return;
            }

            BaggageInformation[] baggages = new BaggageInformation[count];

            double average, total_weight = 0;
            int total_number = 0;

            for (int i = 0; i < DataGrid.Items.Count; i++)
            {
                baggages[i] = (BaggageInformation)DataGrid.Items[i];
            }

            for (int i = 0; i < baggages.Length; i++)
            {
                total_number += baggages[i].Numbers_of_items;
                total_weight += baggages[i].Weight_in_kilograms;
            }

            average = total_weight / total_number;

            double average2;
            int enumerable = 0;

            for (int i = 0; i < baggages.Length; i++)
            {
                average2 = baggages[i].Weight_in_kilograms / baggages[i].Numbers_of_items;

                if(Math.Abs(average - average2) <= 0.3)
                {
                    enumerable = i + 1;
                }
            }
            Result.Text = $"{enumerable}";
        }
    }
}
