using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryTest.DTO
{
    /// <summary>
    /// Размеры упаковки товаров
    /// </summary>
    public class Dimensions 
    {
        //ширина
        public int Width { get; set; }
        //глубина
        public int Depth { get; set; }
        //высота
        public int Height { get; set; }
    }
}
