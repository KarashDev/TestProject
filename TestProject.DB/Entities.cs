using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestProject.DB
{
    public class Entities
    {
        [Table("Проданные_авто")]
        public class CarSales
        {
            public int Id { get; set; }

            [Column("Наименование")]
            public string Name { get; set; }

            [Column("Производитель")]
            public string Manufacturer { get; set; }

            [Column("Сколько_продано")]
            public int NumberOfSold { get; set; }

            [Column("Дата_продажи")]
            public DateTime DateOfSale { get; set; }
        }
    }
}
