using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    interface IDisplayable
    {
        void Show(string data);
    }

    class ConsoleDisplayable : IDisplayable
    {

        public void Show(string data)
        {
            Console.WriteLine(data);
        }
    }
}
