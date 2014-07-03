using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RestaurantLib
{
	public class XmlRepository : IRepository
	{
		private string fileName;
        XmlSerializer xmlSerializer;
        private Dishes dishes;

		public XmlRepository(string fileName)
        {
            this.fileName = fileName;
			xmlSerializer = new XmlSerializer(typeof(List<Dish>));
			dishes = new Dishes();
		}

		public void OpenFile()
		{
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
				dishes = (Dishes)xmlSerializer.Deserialize(fs);
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
				xmlSerializer.Serialize(fStream, dishes);
            }
		}


		public void Add(IEnumerable<Dish> dishes)
		{
			throw new NotImplementedException();
		}
	}

    
}
