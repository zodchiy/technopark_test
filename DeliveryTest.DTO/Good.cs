using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryTest.DTO
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Good
    {
        //идентификатор
        public int Id { get; set; }
        //наименование
        public string Name { get; set; }
        //вес
        public decimal Weight { get; set; }
        //размеры
        public Dimensions Dimensions { get; set; }
    }
}
