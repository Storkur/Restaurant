using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLib
{
	public class Dishes : IEnumerable<Dish>
	{
		private List<Dish> dishes = new List<Dish>();

		public Dish this[int index]
		{
			get { return dishes[index]; }
			set { dishes[index] = value; }
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return dishes.GetEnumerator();
		}

		public void Add(Dish dish)
		{
			dishes.Add(dish);
		}

		public void Remove (Dish dish)
		{
			dishes.Remove(dish);
		}

		public void Edit(Dish dish)
		{
			Dish oldDish = dishes.Find(d => d.Name == dish.Name);
			oldDish = dish;
		}

		IEnumerator<Dish> IEnumerable<Dish>.GetEnumerator()
		{
			return dishes.GetEnumerator();
		}
	}
}
