using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant
{
    class Waiter
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
        }

        // взять заказ и отнести повару
        //public void TakeOrder(List<Client> clients, IEnumerable<Dish> dishes, List<Cook> cooks)
        //{
        //    foreach (Client client in clients)
        //    {
        //        if (client.WaitingOrder)
        //        {
        //            client.Order(dishes);
        //            CurrentClient = client;
        //            Busy = true;
        //            Console.WriteLine("Официант {0} принял заказ у клиента {1}: {2}", Id, CurrentClient.Id, CurrentClient.SelectedDish.Name);
        //            SendOrderToKitchen(cooks);
        //            Thread.Sleep(500);
        //            break;
        //        }
        //    }			
        //}

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

        public void SendOrderToKitchen()
        {

            //foreach (Cook cook in cooks)
            //{
            //    if (!cook.Busy)
            //    {
            //        Console.WriteLine("Официант {0} передает заказ от клиента {1} повару {2}", Id, CurrentClient.Id, cook.Id);
            //        cook.MakeDish(CurrentClient);
            //        this.Busy = false;
            //        return;
            //    }
            //}
            //Console.WriteLine("Официант {0} - нет свободных поваров!", Id);
            //Thread.Sleep(500);
        }

        //public void SendOrderToKitchen(List<Cook> cooks)
        //{
        //    foreach (Cook cook in cooks)
        //        {
        //            if (!cook.Busy)
        //            {
        //                Console.WriteLine("Официант {0} передает заказ от клиента {1} повару {2}", Id, CurrentClient.Id, cook.Id);
        //                cook.MakeDish(CurrentClient);
        //                this.Busy = false;
        //                return;
        //            }
        //        }
        //        Console.WriteLine("Официант {0} - нет свободных поваров!", Id);
        //        Thread.Sleep(500);
        //}
	}
}
