using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_BD.Models
{
    internal class ProductsModel
    {
        public int Id { get; set; }
        public string Products { get; set; }
        public string NumberTel { get; set; }
        public string Name { get; set;}
        public string Address { get; set;}
        public int Price { get; set;}
    }
}
