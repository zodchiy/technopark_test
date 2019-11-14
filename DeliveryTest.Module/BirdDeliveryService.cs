using DeliveryTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryTest.DeliveryServices
{
    /// <summary>
    /// Сервис доставки "Птичка"
    /// </summary>
    public class BirdDeliveryService : DeliveryService
    {
        public BirdDeliveryService() : base (1, "Птичка")
        {}
        public override DeliveryServiceResponse Send(Order order)
        {
            var response = new DeliveryServiceResponse();
            response.serviceId = this.Id;
            response.serviceName = this.Name;
            //пример валидации данных присущие данному поставщику
            if (order.OrderLines.Any(x => x.Good.Dimensions.Depth > 1500) || order.OrderLines.Any(x => x.Good.Dimensions.Width > 1500) || order.OrderLines.Any(x => x.Good.Dimensions.Height > 1500))
            {
                response.somethingIsWrong = true;
                response.errorMessage = "Мы не возим грузы по габаритам больше 150см.";
                return response;
            }
            //тут запрос на api к поставщику и получение данных по расчетам доставки
            var result = new { date = 4, cost = 376.00M };
            //формируем ответ клиенту
            response.deliveryDate = DateTime.Now.AddDays(result.date);
            response.deliveryCost = result.cost;           
            return response;
        }
    }
}
