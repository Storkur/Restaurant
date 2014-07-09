using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantLib
{
    public class Client :IDisplayable
    {
		public bool WaitingDish { get; private set; }
		public bool WaitingOrder { get; private set; }
		public IDisplay Display { get; set; }
		public int Id { get; set; }
		public Dish SelectedDish { get; private set; }
        static Random rnd;
        static int id;
        

        public delegate void ClientHandler(Order order);
        public delegate void ClientPaidHandler(Client client);
        public event ClientHandler Ordered;
        public event ClientPaidHandler Paid;

		public Client(IDisplay disp)
		{
            ++id;
            Id = id;
			WaitingOrder = true;
			WaitingDish = false;
			Display = disp;
		}
		public void Order(IEnumerable<Dish> dishes)
        {
            rnd = new Random();
            int dishNum = rnd.Next(0, dishes.Count());
			SelectedDish = dishes.ElementAt(dishNum);
			Display.Show(String.Format("Клиент № {0} выбрал блюдо {1} \t {2}", Id, SelectedDish.Name, SelectedDish.Price));
			WaitingOrder = false;
            Ordered.BeginInvoke(new Order { client = this, dish = SelectedDish }, null, null);
			
		}
        public void Eat()
        {
			Display.Show(String.Format("Клиент {0} есть", Id));
			Thread.Sleep(WaitTime.ToEat);
			Pay(SelectedDish.Price);
		}
        public void Pay(decimal sum)
        {
			Display.Show(String.Format("Клиент {0} доволен и платит {1}", Id, sum));
            Paid.BeginInvoke(this, null, null);
		}

	}
}
