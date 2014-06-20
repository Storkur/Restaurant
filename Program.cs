using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Restoran restoran = new Restoran(2, 3, new ListRepository());
            restoran.ShowDishes();

			

			//Запуск работы ресторана
			restoran.Service();

            Console.ReadLine();
        }
    }
}
