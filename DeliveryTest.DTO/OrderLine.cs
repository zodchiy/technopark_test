using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryTest.DTO
{
    /// <summary>
    /// Строка заказа
    /// </summary>
    public class OrderLine
    {
        //товар
       public Good Good { get; set; }
        //количество
       public int Qty { get; set; }

    }
}
