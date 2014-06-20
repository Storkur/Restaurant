using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant
{
	class Cook
	{
        private static int id=0;
		public int Id { get; private set; }

        IDisplayable display;

        public delegate void CookHandler(Order order);
        public event CookHandler Finished;

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
		public bool DishReady { get; private set; }
		public string Name { get; set; }
		public Client CurrentClient { get; private set; }

		public Cook(IDisplayable disp)
		{
            display = new ConsoleDisplayable();
			Id = ++id;
			Busy = false;
			DishReady = false;
		}


        public void MakeDish(Order order)
        {
            Busy = true;
            order.cook = this;
            Thread.Sleep(500);
            DishReady = true;
            Console.WriteLine("Повар {0} - еда для клиента {1} готова", Id, order.client.Id);
            Finished(order);
        }


	}
}
