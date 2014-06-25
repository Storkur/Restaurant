using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantLib
{
    public class Waiter
    {
        static int id = 0;
		public int Id { get; private set; }

        public delegate void WaiterHandler(Order order);
        public event WaiterHandler ToCook;

		bool busy;
		public bool Busy 
		{ 
			get
			{
				return busy;
			}
			private set
			{
				if (value == false)
				{ CurrentClient = null; }
				busy = value;
			}
		}

		public Client CurrentClient { get; private set; }
		public bool CarringDish{ get; private set; }


		public Waiter()
		{
			Busy = false;
			CarringDish = false;
			Id = ++id;
		}

        public void TakeOrder(Order order)
        {
            order.waiter = this;
            Busy = true;
            Console.WriteLine("Официант {0} принял заказ у клиента {1}: {2}", Id, order.client.Id, order.dish.Name);
            ToCook(order);
            Thread.Sleep(500);
			Busy = false;
        }

   

        // отнести блюдо клиенту
        public void GiveDishToClient(Client client)
        {
			Busy = true;
			CarringDish = true;
			CurrentClient = client;
			Console.WriteLine("Официант {0} передает готовое блюдо клиенту {1}", Id, client.Id);
			Thread.Sleep(500);
			client.Eat();
			Busy = false;
			CarringDish = false;
		}
	}
}
