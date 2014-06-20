using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Dish
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Dish(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    class Order
    {
        protected internal Dish dish { get; set; }
        protected internal Client client { get; set; }
        protected internal Waiter waiter { get; set; }
        protected internal Cook cook { get; set; }
    }
}
