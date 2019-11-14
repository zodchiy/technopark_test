using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryTest.DeliveryServices
{
    /// <summary>
    /// Доступный список поставщиков
    /// тут могут происходить инициализация, проверка на доступнойсть и прочее...
    /// </summary>
    public static class DeliveryServicesList 
    {
        private static List<DeliveryService> services { get; set; }
        static DeliveryServicesList()
        {
            if(services == null)
            {
                services = new List<DeliveryService>();                
                var bird = new BirdDeliveryService();
                services.Add(bird);
                var tort = new TortoiseDeliveryService();
                services.Add(tort);
            }
        }        
        public static List<DeliveryService> GetAll()
        {
            return services;
        }
    }
}
