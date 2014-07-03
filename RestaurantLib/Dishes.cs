using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLib
{
	class Dishes : IEnumerable
	{
		private List<Dish> dishes = new List<Dish>();

		public Dish this[int index]
		{
			get { return dishes[index]; }
			set { dishes[index] = value; }
		}
		public IEnumerator GetEnumerator()
		{
			return dishes.GetEnumerator();
		}
	}
}
