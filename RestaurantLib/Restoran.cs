using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RestaurantLib
{
	public class Restoran : Eats
	{
		private int timeBetweenClients = 2000;

		List<Waiter> waiters;
		static Random rnd;

		IDisplayable display;

		public Restoran(int numOfCooks, int numOfWaiters, IRepository db)
			: base(numOfCooks, db)
		{
			display = new ConsoleDisplayable();
			rnd = new Random();
			waiters = new List<Waiter>();

			AddCooks(numOfCooks);

			AddWaiters(numOfWaiters);
		}

		public void ShowDishes()
		{
			if (dishes != null)
			{
				foreach (Dish d in dishes)
				{
					Console.WriteLine("Название: {0} -  Цена: {1}", d.Name, d.Price);
				}
			}
			else
			{
				Console.WriteLine("Список блюд пуст!");
			}
		}

		public void Service()
		{
			int i = 0;
			while (i < 30)  //Для отладки
			{
				i++;
				AddClient();
				AddClient();
				AddClient();
				AddClient();

				display.Show("------------------Пауза------------------------------");
				Thread.Sleep(WaitTime.BetweenClients);
			}
		}

		public void TakeOrder(Order order)
		{
			bool found = false;
			while (!found)
			{
				for (int i = 0; i < waiters.Count; i++)
				{
					if (!waiters[i].Busy)
					{
						waiters[i].TakeOrder(order);
						found = true;
						break;
					}
				}
			}
		}
		public void Restoran_ToCook(Order order)
		{
			bool found = false;
			while (!found)
			{
				//waiter1= waiters[rnd.Next(0, waiters.Count-1)];
				for (int i = 0; i < cooks.Count; i++)
				{
					if (!cooks[i].Busy)
					{
						cooks[i].MakeDish(order);
						found = true;
						break;
					}
				}
			}
		}

		public void Restoran_Finished(Order order)
		{
			order.waiter.GiveDishToClient(order.client);
		}

		public void client_Paid(Client client)
		{
			RemoveClient(client);
		}

		private void AddWaiters(int n)
		{
			for (int i = 0; i < n; i++)
			{
				Waiter waiter = new Waiter();
				waiter.ToCook += Restoran_ToCook;
				waiters.Add(waiter);
			}
		}

		private void AddCooks(int n)
		{
			for (int i = 0; i < n; i++)
			{
				Cook c = new Cook(display);
				c.Finished += Restoran_Finished;
				cooks.Add(c);

			}
		}

		public void AddClient()
		{
			Client client = new Client();
			clients.Add(client);

			Console.WriteLine("Пришел клиент: № {0}", client.Id);
			client.Ordered += TakeOrder;
			client.Paid += client_Paid;
			client.Order(dishes);
		}

		public void RemoveClient(Client client)
		{
			Console.WriteLine("Ушел клиент: № {0}", client.Id);
			clients.Remove(client);
		}

	}

	public abstract class Eats
	{
		protected List<Client> clients;
		protected IEnumerable<Dish> dishes;
		protected List<Cook> cooks;
		IRepository db;

		public Eats(int numOfCooks, IRepository db)
		{
			clients = new List<Client>();
			cooks = new List<Cook>();
			this.db = db;
			dishes = GetDishes(db);
			db.Save();

		}

		/// <summary>
		/// Обновить ссылку на хранилище
		/// </summary>
		/// <param name="db"></param>
		/// <returns>Меню</returns>
		public IEnumerable<Dish> GetDishes(IRepository db)
		{
			this.db = db;
			return db.GetDishes();
		}

		/// <summary>
		/// Обновить меню из хранилища
		/// </summary>
		public void RefreshDishes()
		{
			dishes = db.GetDishes();
		}

	}


}
