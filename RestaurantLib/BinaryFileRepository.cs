using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RestaurantLib
{
	public class BinaryFileRepository : IRepository
	{
		private string fileName;
		private Dishes dishes;

		public BinaryFileRepository(string fileName)
		{
			this.fileName = fileName;
			dishes = new Dishes();
		}

		public IEnumerable<Dish> GetDishes()
		{
			using(BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate)))
			{
				dishes = new Dishes();
				while (br.BaseStream.Position < br.BaseStream.Length)
				{
					var name = br.ReadString();
					var price = br.ReadDecimal();
					dishes.Add(new Dish(name, price));
				}
			}
			return dishes;
		}

		public void Add(Dish dish)
		{
			dishes.Add(dish);
		}

		public void Delete(Dish dish)
		{
			dishes.Remove(dish);
		}

		public void Edit(Dish dish)
		{
			dishes.Edit(dish);
		}

		public void Save()
		{
			using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
			{
				foreach (Dish dish in dishes)
				{
					bw.Write(dish.Name);
					bw.Write(dish.Price);
				}
			}
		}


		public void Add(IEnumerable<Dish> dishes)
		{
			this.dishes.AddRange(dishes);
		}
	}
}
