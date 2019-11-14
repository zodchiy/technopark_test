using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryTest.DeliveryServices
{
    /// <summary>
    /// Ответ клиенту от сервиса доставки
    /// </summary>
    public class DeliveryServiceResponse
    {
        //Идентификатор сервиса доставки
        public int serviceId { get; set; }
        //Наименование сервиса доставки
        public string serviceName { get; set; }
        //Произошла ошибка
        public bool somethingIsWrong { get; set; }
        //Описание ошибки
        public string errorMessage { get; set; }

        //Дата доставки
        public DateTime deliveryDate { get; set; }
        //Стоимость доставки
        public decimal deliveryCost { get; set; }

    }
}
