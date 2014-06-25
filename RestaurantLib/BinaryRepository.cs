using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RestaurantLib
{
	public class BinaryRepository : IRepository
	{
		private string fileName;
        BinaryFormatter bf;
        private List<Dish> dishes;

		public BinaryRepository(string fileName)
        {
            this.fileName = fileName;
            bf = new BinaryFormatter();
            dishes = new List<Dish>();
		}

		public void OpenFile()
		{
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                dishes = (List<Dish>)bf.Deserialize(fs);
            }
		}

		public IEnumerable<Dish> GetDishes()
		{
		    return dishes;
		}

		public void Add(Dish dish)
		{
            dishes.Add(dish);
		}

		public void Delete(Dish dish)
		{
			throw new NotImplementedException();
		}

		public void Edit(Dish dish)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
            using (Stream fStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                bf.Serialize(fStream, dishes);
            }
		}
	}

    
}
