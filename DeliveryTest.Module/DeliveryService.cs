using DeliveryTest.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryTest.DeliveryServices
{
    /// <summary>
    /// Сервис доставки
    /// </summary>
    public abstract class DeliveryService
    {
        public DeliveryService(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        //Идентификатор поставщика
        public int Id { get; protected set; }
        //Наименование поставщика
        public string Name { get; protected set; }
        //Расчет стоимости поставки
        public abstract DeliveryServiceResponse Send(Order order);
    }
}
