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

namespace RestaurantForm
{
	public enum Modes
	{
		Add,
		Edit,
		Remove
	};
    public partial class DishForm : Form
    {
        MainForm parent;
        Dish dish;
		Modes mode;
        public DishForm(MainForm parent, Modes mode, Dish dish = null)
        {
            InitializeComponent();

            this.parent = parent;
			this.mode = mode;
            if (dish != null)
            {
                this.dish = dish;
				textName.Text = dish.Name;
				numPrice.Value = dish.Price;
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Apply();
			this.Close();
		}

		private void Apply()
		{
			if (mode == Modes.Edit)
			{
				parent.EditDish(new Dish(dish.Name, numPrice.Value));
			}
			else if (mode == Modes.Add)
			{
				parent.AddDish(new Dish(textName.Text, numPrice.Value));
			}
			else if (mode == Modes.Remove)
			{
				parent.RemoveDish(new Dish(textName.Text, numPrice.Value));
			}
		}

		private void btnApply_Click(object sender, EventArgs e)
		{

		}


	}
}
