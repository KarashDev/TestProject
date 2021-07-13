using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.BL
{
    public class RussianTableForDataGrid
    {
        public string Название { get; set; }
        public string Производитель { get; set; }
        public int ПроданоШтук { get; set; }
        // Поле имеет тип string а не DateTime, т.к. в таблице пользователь должен видеть
        // "урезанную" дату без времени, для этого требуется переводить DateTime в string
        public string ДатаПродажи { get; set; }
    }
}
