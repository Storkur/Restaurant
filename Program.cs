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
			//BinaryFileRepository binFileRep = new BinaryFileRepository(@"test.bin");
			ListRepository dishes = new ListRepository();
			//binFileRep.Save();

			Restoran restoran = new Restoran(3, 3, dishes);
			restoran.Display = new ConsoleDisplayable();
            restoran.ShowDishes();

			

			//Запуск работы ресторана
			restoran.Service();

            

            Console.ReadLine();
        }
    }
}
