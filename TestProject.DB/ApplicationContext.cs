using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static TestProject.DB.Entities;

namespace TestProject.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CarSales> CarSalesTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=TestProjectDB;Integrated Security=True");
        }
    }

}
