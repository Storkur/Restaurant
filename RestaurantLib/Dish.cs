using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLib
{
	[Serializable]
    public class Dish
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Dish(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

		public Dish() 
		{
		}
    }

    public class Order
    {
        public Dish dish { get; set; }
        public Client client { get; set; }
        public Waiter waiter { get; set; }
        public Cook cook { get; set; }
    }
}
