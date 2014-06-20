using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant
{
    class Client
    {
		public bool WaitingDish { get; private set; }
		public bool WaitingOrder { get; private set; }
		public int Id { get; set; }
		public Dish SelectedDish { get; private set; }
        static Random rnd;
        static int id;
        

        public delegate void ClientHandler(Order order);
        public delegate void ClientPaidHandler(Client client);
        public event ClientHandler Ordered;
        public event ClientPaidHandler Paid;

		public Client()
		{
            ++id;
            Id = id;
			WaitingOrder = true;
			WaitingDish = false;
		}
		public void Order(IEnumerable<Dish> dishes)
        {
            rnd = new Random();
            int dishNum = rnd.Next(0, dishes.Count()-1);
			SelectedDish = dishes.ElementAt(dishNum);
			Console.WriteLine("Клиент № {0} выбрал блюдо {1} \t {2}", Id, SelectedDish.Name, SelectedDish.Price);
			WaitingOrder = false;
            Ordered(new Order { client = this, dish = SelectedDish });
			
		}
        public void Eat()
        {
			Console.WriteLine("Клиент {0} есть", Id);
			Thread.Sleep(500);
			Pay(SelectedDish.Price);
		}
        public void Pay(decimal sum)
        {
			Console.WriteLine("Клиент {0} доволен и платит {1}", Id, sum);
            Paid(this);
		}

	}
}
