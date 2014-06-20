using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
	class FileRepository : IRepository
	{
		public IEnumerable<Dish> GetDishes()
		{
			throw new NotImplementedException();
		}

		public void Add(Dish dish)
		{
			throw new NotImplementedException();
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
        }
	}
}
