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
			BinaryFileRepository binFileRep = new BinaryFileRepository(@"C:\tmp\test.bin");

			Restoran restoran = new Restoran(3, 3, binFileRep);
            restoran.ShowDishes();

			

			//Запуск работы ресторана
			restoran.Service();

            

            Console.ReadLine();
        }
    }
}
