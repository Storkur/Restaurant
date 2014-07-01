using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantLib
{
	public class Cook : IDisplayable
	{
        private static int id=0;
		public int Id { get; private set; }
		public IDisplay Display { get; set; }

        public delegate void CookHandler(Order order);
        public event CookHandler Finished;

		public bool Busy {get; set;}

		public bool DishReady { get; private set; }

		public Cook(IDisplay disp)
		{
            Display = disp;
			Id = ++id;
			Busy = false;
			DishReady = false;
		}


        public void MakeDish(Order order)
        {
            Busy = true;
            order.cook = this;
            Thread.Sleep(WaitTime.MakeDish);
            DishReady = true;
            Display.Show(String.Format("Повар {0} - еда для клиента {1} готова", Id, order.client.Id));
            Finished.BeginInvoke(order, null, null);
			Busy = false;
			DishReady = false;
        }


	}
}
