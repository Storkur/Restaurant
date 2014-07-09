using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantLib;
using System.Threading;

namespace RestaurantForm
{
	public partial class WorkDynamicsForm : Form
	{
		private Restoran restoran;
		public WorkDynamicsForm(Restoran restoran)
		{
			InitializeComponent();

			this.restoran = restoran;
			SetupRestoranDataGrid();
			Visualize();
		}

		private void SetupRestoranDataGrid()
		{
			RestoranDataGrid.ColumnCount = 3;
			RestoranDataGrid.RowCount = restoran.Clients.Count();
			RestoranDataGrid.Columns[0].Name = "Клиент";
			RestoranDataGrid.Columns[1].Name = "Официант";
			RestoranDataGrid.Columns[2].Name = "Повар";

			RestoranDataGrid.Rows[0].Cells[0].Value = "test";
		}

		private void Visualize()
		{
			string value;

			RestoranDataGrid.RowCount = restoran.Clients.Count();

			for (int i = 0; i < restoran.Clients.Count; i++)
			{
				var c = restoran.Clients[i];
				value = c.Id.ToString();
				value += " \nSelectedDish " + c.SelectedDish.Name;
				RestoranDataGrid.Rows[i].Cells[0].Value = value;
			}

			for (int i = 0; i < restoran.Waiters.Count; i++)
			{
				var w = restoran.Waiters[i];
				value = w.Id.ToString();
				value += " \nBusy " + w.Busy;
				value += " \nCarringDish " + w.CarringDish;
				RestoranDataGrid.Rows[i].Cells[1].Value = value;
			}

			for (int i = 0; i < restoran.Cooks.Count; i++)
			{
				var c = restoran.Cooks[i];
				value = c.Id.ToString();
				value += " \nBusy " + c.Busy;
				value += " \nDishReady " + c.DishReady;
				RestoranDataGrid.Rows[i].Cells[2].Value = value;
			}
		}
	}
}
