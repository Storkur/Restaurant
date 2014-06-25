using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLib
{
   public class ListRepository : IRepository
    {
        private List<Dish> dishes;


        public ListRepository()
        {
            dishes = new List<Dish>();
            dishes.Add(new Dish("Пицца", 12.77m));
			dishes.Add(new Dish("Салат", 5.5m));
			dishes.Add(new Dish("Булочка", 4.35m));
			dishes.Add(new Dish("Мясо", 14.0m));
			dishes.Add(new Dish("Овощи", 8.2m));
			dishes.Add(new Dish("Кофе", 4.5m));
			dishes.Add(new Dish("Чай", 4.0m));
			dishes.Add(new Dish("Вода", 2.5m));
			dishes.Add(new Dish("Хлеб", 2.5m));
			dishes.Add(new Dish("Сок", 4.5m));
			dishes.Add(new Dish("Вино", 6.2m));
			dishes.Add(new Dish("Рыба", 15.6m));
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
            dishes.Remove(dish);
        }

        public void Edit(Dish dish)
        {
           Dish oldDish = dishes.Find(d => d.Name == dish.Name);
           oldDish = dish;
        }

        public void Save()
        { }
    }
}
