using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RestaurantLib
{
	public class LinqToXmlRepository : IRepository
	{
		private Dishes dishes = new Dishes();

		public IEnumerable<Dish> GetDishes()
		{
			XDocument xdoc = new XDocument(); 

			try
			{
				xdoc = XDocument.Load("data.xml");
			}

			catch (System.IO.FileNotFoundException ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}

			var dishes = from dish in xdoc.Descendants("Dish")
						 select new
						 {
							 Name = dish.Attribute("Name").Value,
							 Price = dish.Element("Price").Value
						 };

			if(dishes != null)
			{
				this.dishes = new Dishes();
				foreach (var dish in dishes)
				{
					this.dishes.Add(new Dish(dish.Name, Decimal.Parse(dish.Price, NumberStyles.Any, CultureInfo.InvariantCulture)));
				}
			}		

			return this.dishes;
		}

		public void Add(Dish dish)
		{
			dishes.Add(dish);
		}

		public void Add(IEnumerable<Dish> dishes)
		{
			this.dishes.AddRange(dishes);
		}

		public void Delete(Dish dish)
		{
			dishes.Remove(dish);
		}

		public void Edit(Dish dish)
		{
			dishes.Edit(dish);
		}

		public void Save()
		{
			XDocument xdoc = new XDocument(
				new XElement("Dishes",	
					from dish in dishes 
					select 
					new XElement("Dish", 
						new XAttribute("Name", dish.Name),
						new XElement("Price", dish.Price))));

			xdoc.Save("data.xml");
		}
	}
}
