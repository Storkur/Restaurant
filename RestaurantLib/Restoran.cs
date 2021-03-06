﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RestaurantLib
{
	public class Restoran : Eats, IDisplayable
	{
		private int timeBetweenClients = 2000;

		List<Waiter> waiters;

		public List<Waiter> Waiters
		{
			get { return waiters; }
			private set { waiters = value; }
		}

		static Random rnd;

		public IDisplay Display { get; set; }

		public Restoran(int numOfCooks, int numOfWaiters, IRepository db)
			: base(numOfCooks, db)
		{
			Display = new FileLog();
			rnd = new Random();
			waiters = new List<Waiter>();

			AddCooks(numOfCooks);

			AddWaiters(numOfWaiters);
		}

		public void ShowDishes()
		{
			if (Dishes != null)
			{
				foreach (Dish d in Dishes)
				{
					Display.Show(String.Format("Название: {0} -  Цена: {1}", d.Name, d.Price));
				}
			}
			else
			{
				Display.Show(String.Format("Список блюд пуст!"));
			}
		}

		public void Service()
		{
			if (!Dishes.Any())
			{
				Console.WriteLine("Пустое меню! Обслуживание клиентов невозможно!");
				return;
			}
			int i = 0;
			while (i < 30)  //Для отладки

			{
				i++;
				AddClient();
				AddClient();
				AddClient();
				AddClient();

				Display.Show("------------------Пауза------------------------------");
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
				for (int i = 0; i < Cooks.Count; i++)
				{
					if (!Cooks[i].Busy)
					{
						Cooks[i].MakeDish(order);
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
				Waiter waiter = new Waiter(Display);
				waiter.ToCook += Restoran_ToCook;
				waiters.Add(waiter);
			}
		}

		private void AddCooks(int n)
		{
			for (int i = 0; i < n; i++)
			{
				Cook c = new Cook(Display);
				c.Finished += Restoran_Finished;
				Cooks.Add(c);

			}
		}

		public void AddClient()
		{
			Client client = new Client(Display);
			Clients.Add(client);

			Display.Show(String.Format("Пришел клиент: № {0}", client.Id));
			client.Ordered += TakeOrder;
			client.Paid += client_Paid;
			client.Order(Dishes);
		}

		public void RemoveClient(Client client)
		{
			Display.Show(String.Format("Ушел клиент: № {0}", client.Id));
			Clients.Remove(client);
		}
	}

	public abstract class Eats
	{
		protected List<Client> clients;
		protected IEnumerable<Dish> dishes;
		protected List<Cook> cooks;

		public List<Client> Clients
		{
			get { return clients; }
			private set { clients = value; }
		}		

		public IEnumerable<Dish> Dishes
		{
			get { return dishes; }
			private set { dishes = value; }
		}		

		public List<Cook> Cooks
		{
			get { return cooks; }
			private set { cooks = value; }
		}

		IRepository db;

		public Eats(int numOfCooks, IRepository db)
		{
			clients = new List<Client>();
			cooks = new List<Cook>();
			this.db = db;
			dishes = GetDishes(db);
			if (!dishes.Any())
			{
				Console.WriteLine("Пустое меню!");
			}
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
