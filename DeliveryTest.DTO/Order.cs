using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryTest.DTO
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        //Адрес получения
        public string AddressDestination { get; set; }
        //Адрес отправки
        public string AddressDeparture { get; set; }
        //список товаров
        public List<OrderLine> OrderLines { get;set;}

        public void AddLine(Good good, int qty)
        {
            if(OrderLines == null)
            {
                OrderLines = new List<OrderLine>();
            }
            var newline = new OrderLine();
            newline.Good = good;
            newline.Qty = qty;
            OrderLines.Add(newline);
        }
    }
}
