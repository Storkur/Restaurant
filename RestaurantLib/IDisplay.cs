using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RestaurantLib
{
    public interface IDisplay
    {
        void Show(string data);
    }

    public class ConsoleDisplayable : IDisplay
    {

        public void Show(string data)
        {
            Console.WriteLine(data);
        }
    }

    public class WindowsFormsDisplayable : IDisplay
    {

        public void Show(string data)
        {
            MessageBox.Show(data);
        }
    }

	public class FileLog : IDisplay
	{
		private static object locker = new object();

		public void Show(string data)
		{
			lock (locker)
			{
				using (StreamWriter sw = new StreamWriter("log.txt", true))
				{
					sw.WriteLine(data);
				}
			}
		}
	}
}
