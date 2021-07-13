using System;
using System.Collections.Generic;
using System.Text;
using static TestProject.DB.Entities;

namespace TestProject.DB
{
    public static class DataBaseCreator
    {
        public static CarSales CreateCarSalesTable(string autoName, string manufacturer, int numberOfSold, DateTime dateOfSale)
        {
            return new CarSales
            {
                Name = autoName,
                Manufacturer = manufacturer,
                NumberOfSold = numberOfSold,
                DateOfSale = dateOfSale
            };
        }

        static DateTime CreateDateTimeFormat(string actualDateTime, string formatDateTime)
        {
            return DateTime.ParseExact(actualDateTime, formatDateTime, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static void CreateDataBase()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                List<CarSales> carSales = new List<CarSales>(15)
                {
                CreateCarSalesTable("Solaris","Hyundai", 5, CreateDateTimeFormat("03.01.2021 13:55:03", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("Rio","Kia", 2, CreateDateTimeFormat("13.01.2021 08:53:01", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("i8","BMW", 12, CreateDateTimeFormat("08.02.2021 13:47:03", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("Focus","Ford", 4, CreateDateTimeFormat("21.02.2021 18:04:45", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("Pilot","Honda", 7, CreateDateTimeFormat("04.03.2021 21:01:05", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("Corolla","Toyota", 1, CreateDateTimeFormat("06.03.2021 03:21:08", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("Logan","Renault", 11, CreateDateTimeFormat("22.04.2021 02:33:21", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("Mondeo","Ford", 2, CreateDateTimeFormat("02.05.2021 22:13:17", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("Tacoma","Toyota", 5, CreateDateTimeFormat("07.05.2021 17:03:22", "dd.MM.yyyy HH:mm:ss")),
                CreateCarSalesTable("Calina","Lada", 7, CreateDateTimeFormat("18.05.2021 15:53:45", "dd.MM.yyyy HH:mm:ss")),
                };

                foreach (var carInfo in carSales)
                {
                    db.Add(carInfo);
                }

                db.SaveChanges();
            }


        }
    }
}
