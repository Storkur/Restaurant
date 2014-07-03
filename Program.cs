using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLib;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
			BinaryFileRepository dishes = new BinaryFileRepository(@"test.bin");

			if (!dishes.GetDishes().Any()) //Если в файле нет меню, то запишем в файл заготовку
			{
				ListRepository dishes1 = new ListRepository();
				dishes.Add(dishes1.GetDishes());
				dishes.Save();
			}
			

			Restoran restoran = new Restoran(3, 3, dishes);
			restoran.Display = new ConsoleDisplayable();
            restoran.ShowDishes();

			

			//Запуск работы ресторана
			restoran.Service();

            

            Console.ReadLine();
        }
    }
}
