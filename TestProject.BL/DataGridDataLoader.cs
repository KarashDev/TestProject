using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.DB;

namespace TestProject.BL
{
    public static class DataGridDataLoader
    {
        public static IQueryable<RussianTableForDataGrid> GetTableInRussian(ApplicationContext context)
        {
            var fetchForDataGrid = context.CarSalesTable.Select(carSales => new RussianTableForDataGrid
            {
                Название = carSales.Name,
                Производитель = carSales.Manufacturer,
                ПроданоШтук = carSales.NumberOfSold,
                ДатаПродажи = carSales.DateOfSale.ToString("dd.MM.yyyy")
            });
            return fetchForDataGrid;
        }
    }
}
