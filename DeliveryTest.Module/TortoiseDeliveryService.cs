using DeliveryTest.DTO;
using System;
using System.Linq;

namespace DeliveryTest.DeliveryServices
{
    /// <summary>
    /// Сервис доставки "Черепашка"
    /// </summary>
    public class TortoiseDeliveryService : DeliveryService
    {
        public TortoiseDeliveryService() : base(2, "Черепашка") { }
        //базовая стоимость доставки
        const decimal CostFactor = 150M;
        public override DeliveryServiceResponse Send(Order order)
        {
            var response = new DeliveryServiceResponse();
            response.serviceId = this.Id;
            response.serviceName = this.Name;
            //пример валидации данных присущие данному поставщику
            if (order.OrderLines.Sum(x=>x.Good.Weight) > 200.0M)
            {
                response.somethingIsWrong = true;
                response.errorMessage = "Мы не возим грузы больше 200 кг одним заказом.";
                return response;
            }
            //тут запрос на api к поставщику и получение данных по расчетам доставки
            var result = new { date = DateTime.Now.AddDays(5), cost = 1.75M};
            //формируем ответ клиенту
            response.deliveryDate = result.date;
            response.deliveryCost = result.cost * CostFactor;            
            return response;
        }
                
    }
}