using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLib
{
    public interface IRepository
    {
        IEnumerable<Dish> GetDishes();
        void Add(Dish dish);
		void Add(IEnumerable<Dish> dishes);
        void Delete(Dish dish);
        void Edit(Dish dish);
        void Save();
    }
}
