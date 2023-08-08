using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract17.Database
{
    public class DataBase : DbContext
    {
        public DataBase()
        {
            Database.EnsureCreated();
        }

        public DbSet<Участники> Участники { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Trusted_Connection=true;TrustServerCertificate=true;Database=Участники бальных танцев");*/ // - строка подключения дома
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;User id = ИСП-31;Password=1234567890;TrustServerCertificate=true;Database=Участники бальных танцев"); // - строка подключения в колледже
        }
    }
}
