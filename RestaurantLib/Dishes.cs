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
			get 
			{
				if (dishes.Any())
					return dishes[index];
				else return new Dish("", 0);
			}
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

		public void AddRange(IEnumerable<Dish> dishes)
		{
			this.dishes.AddRange(dishes);
		}

		public void Remove (Dish dish)
		{
			dishes.Remove(dish);
		}

		public void Edit(Dish dish)
		{
			int i = dishes.FindIndex(d => d.Name == dish.Name);
			dishes[i] = dish;
		}

        IEnumerator<Dish> IEnumerable<Dish>.GetEnumerator()
        {
            return dishes.GetEnumerator();
        }

        public IEnumerable<Dish> GetDishes()
        {
            for (int i = 0; i < dishes.Count(); i++)
            {
                yield return dishes[i];
            }
        }
	}
}
