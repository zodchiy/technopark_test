using DeliveryTest.DeliveryServices;
using DeliveryTest.DTO;
using System;
using System.Linq;
namespace DeliveryTest.TestConsole
{
    class Program
    {
        /// <summary>
        /// Быстрый тестовый говнокод для себя
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var order = new Order();
            order.AddressDeparture = "г. Москва, ул. Привокзальная, дом 15";
            order.AddressDestination = "Московская область, г. Мытищи, ул. Прямокривоугольная, дом 4Б";
            var good1 = new Good{ Id = 1, Dimensions = DimGen(), Name = "Коробка картонная пустая", Weight = rndWeightGen() };
            order.AddLine(good1, 3);
            var good2 = new Good { Id = 2, Dimensions = DimGen(), Name = "Коробка картонная не пустая", Weight = rndWeightGen() };
            order.AddLine(good2, 2);
            var good3 = new Good { Id = 3, Dimensions = DimGen(), Name = "Коробка картонная с чем-то", Weight = rndWeightGen() };
            order.AddLine(good3, 1);
            var good4 = new Good { Id = 4, Dimensions = DimGen(), Name = "Коробка с чем-то еще", Weight = rndWeightGen() };
            order.AddLine(good4, 1);
            Console.WriteLine("Заказ:");
            Console.WriteLine($"Адрес отправителя:{order.AddressDeparture}") ;
            Console.WriteLine($"Адрес получателя:{order.AddressDestination}");
            Console.WriteLine("Список товаров:");
            order.OrderLines.ForEach(x => { Console.WriteLine($"{x.Good.Id} - {x.Good.Name}, вес {x.Good.Weight}кг, Ш*В*Д {x.Good.Dimensions.Width}*{x.Good.Dimensions.Depth}*{x.Good.Dimensions.Height}, кол-во - {x.Qty}"); }); 
            Console.WriteLine("Выберите перевозчика для расчета стоимости доставки (Esc для выхода):");
            Console.WriteLine("0 - Все");
            var services = DeliveryServicesList.GetAll();
            if(services == null || !services.Any())
            {
                Console.WriteLine("Нет перевозчиков");
                return;
            }
            services.ForEach(x=> { Console.WriteLine($"{x.Id} - {x.Name}"); });
            while (true)
            {               
                try
                {
                    var DelServ = Int32.Parse(Console.ReadLine());
                    if (DelServ >= 0 && DelServ <= services.Count())
                    {
                        if (DelServ == 0)
                        {
                            var result = services.Select(x => x.Send(order)).ToList();
                            result.ForEach(x =>
                            {
                                if (x.somethingIsWrong) { Console.WriteLine($"{x.serviceName} ответил c ошибкой - {x.errorMessage}"); }
                                else
                                {
                                    Console.WriteLine($"{x.serviceName} ответил -  цена:{x.deliveryCost}, дата: {x.deliveryDate.ToShortDateString()}");
                                }
                            });
                        }
                        else
                        {
                            var result = services.FirstOrDefault(x => x.Id == DelServ).Send(order);
                            if (result.somethingIsWrong) { Console.WriteLine($"{result.serviceName} ответил c ошибкой - {result.errorMessage}"); }
                            else
                            {
                                Console.WriteLine($"{result.serviceName} ответил -  цена:{result.deliveryCost}, дата: {result.deliveryDate.ToShortDateString()}");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите номер.");
                }                
            }
        }

        public static Dimensions DimGen()
        {
            return new Dimensions() { Depth = rndGen(), Height = rndGen(), Width = rndGen() };
        }
        public static int rndGen()
        {
            Random rnd = new Random();
            return rnd.Next(10, 1151) * 10;
        }
        public static decimal rndWeightGen()
        {
            Random rnd = new Random();
            return Math.Round(new decimal(rnd.Next(10, 151000)/1000.0), 2);
        }
    }
}
