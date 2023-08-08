using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.VisualBasic;
using Pract20.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract20.Pages
{
    /// <summary>
    /// Логика взаимодействия для SQL.xaml
    /// </summary>
    public partial class SQL : Page
    {
        CarRepairGetContext db = CarRepairGetContext.GetContext();

        public SQL()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Sql.Number)
            {
                case 1:

                    dgSql.Columns.Add( new DataGridTextColumn { Binding = new Binding("Fullname"), Header="ФИО" });
                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("TotalCost"), Header = "Стоимость выполненных работ" });

                    dgSql.ItemsSource = (from d in db.DirectoryOfPerformersOfWorks
                                         join o in db.Orders on d.IdArtists equals o.IdArtists
                                         join w in db.DirectoryOfTypesOfWorks on o.IdOfTheTypeOfWork equals w.IdWork
                                         group new
                                         {
                                             d.FullName,
                                             totalCost = w.CostOfWork,
                                         }
                                         by d.FullName into g
                                         select new
                                         {
                                             Fullname = g.Key,
                                             TotalCost = g.Sum(x => x.totalCost)
                                         }).ToList();
                    break;

                case 2:

                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("Client"), Header = "Клиент" });
                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("TotalCost"), Header = "Стоимость заказов" });

                    dgSql.ItemsSource = (from w in db.DirectoryOfTypesOfWorks
                                         join o in db.Orders on w.IdWork equals o.IdOfTheTypeOfWork
                                         group new
                                         {
                                             o.Client,
                                             totalCost = w.CostOfWork,
                                         }
                                         by o.Client into g
                                         select new
                                         {
                                             Client = g.Key,
                                             TotalCost = g.Sum(x => x.totalCost)
                                         }).ToList();
                    break;

                case 3:

                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("CarBrand"), Header = "Марка автомобиля" });
                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("OrdersCount"), Header = "Количество заказов" });

                    dgSql.ItemsSource = (from o in db.Orders
                                         group new
                                         {
                                             o.CarBrand,
                                             ordersCount = o.CarBrand
                                         } by o.CarBrand into g
                                         select new
                                         {
                                             CarBrand = g.Key,
                                             OrdersCount = g.Count(x => x.ordersCount == g.Key)
                                         }).ToList();
                    break;

                case 4:

                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("Date"), Header = "Дата" });
                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("NameOfWork"), Header = "Наименование работы" });
                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("OrdersCount"), Header = "Количество заказов" });

                    lSql4.Visibility = Visibility.Visible;
                    tbSql4.Visibility = Visibility.Visible;
                    btSql4.Visibility = Visibility.Visible;
                    break;

                case 5:

                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("OrderNumber"), Header = "Номер заказа" });
                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("Date"), Header = "Дата заказа" });
                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("CarBrand"), Header = "Марка автомобиля" });
                    dgSql.Columns.Add(new DataGridTextColumn { Binding = new Binding("CostOfWork"), Header = "Стоимость заказа" });

                    dgSql.ItemsSource = (from o in db.Orders
                                         join w in db.DirectoryOfTypesOfWorks on o.IdOfTheTypeOfWork equals w.IdWork
                                         where o.Date.Month <= 3 && o.Date.Year == DateTime.Now.Year
                                         select new
                                         {
                                             OrderNumber = o.OrderNumber,
                                             Date = o.Date,
                                             CarBrand = o.CarBrand,
                                             CostOfWork = w.CostOfWork
                                         }).ToList();
                    break;

                case 6:
                    dgSql.Visibility = Visibility.Hidden;
                    lSql6.Visibility = Visibility.Visible;
                    tbSql6.Visibility = Visibility.Visible;

                    var sql = db.DirectoryOfTypesOfWorks.AsEnumerable()
                                        .GroupBy(x => x.NameOfTheWork)
                                        .OrderByDescending(x => x.Count())
                                        .Select(g => g.Key)
                                        .FirstOrDefault();

                    tbSql6.Text = sql;
                    break;
            }
        }

        private void btSql4_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(tbSql4.Text, out DateTime date))
            {
                MessageBox.Show("Введите дату корректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                tbSql4.Clear();
                return;
            }

            dgSql.ItemsSource = (from o in db.Orders
                                 join w in db.DirectoryOfTypesOfWorks on o.IdOfTheTypeOfWork equals w.IdWork
                                 where o.Date == date
                                 group new
                                 {
                                     o.Date,
                                     nameOfWork = w.NameOfTheWork,
                                     ordersCount = o.Date
                                 } by o.Date into g
                                 select new
                                 {
                                     Date = g.Key,
                                     NameOfWork = string.Join(", ",g.Select(x => x.nameOfWork)),
                                     OrdersCount = g.Count(x => x.ordersCount == g.Key)
                                 }).ToList();
        }
    }
}
