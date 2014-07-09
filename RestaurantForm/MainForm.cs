using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using RestaurantLib;

namespace RestaurantForm
{
    public partial class MainForm : Form
    {
        int currentDish;
        //BinaryRepository fileRepo;
		private IRepository repository;

        List<Dish> selectedDishes;
		Dishes dishes;

        public MainForm()
        {
         
            InitializeComponent();

            selectedDishes = new List<Dish>();
			repository = new ListRepository();//new BinaryRepository("dishes.dat");
            repository.Add(new Dish("Кукруза", 12.6m));
            repository.Add(new Dish("Картофель", 15.6m));
            repository.Add(new Dish("Морковь", 14.6m));
			dishes = (Dishes)repository.GetDishes();
            //fileRepo.OpenFile();
            label3.Text = dishes[0].Name;
			label4.Text = dishes[0].Price.ToString();
            currentDish = 0;
        }


        public void AddDish(Dish d)
        {
            repository.Add(d);
          
        }

        public void EditDish(Dish d)
        {
            repository.Edit(d);
        }

		public void RemoveDish(Dish dish)
		{
			repository.Delete(dish);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentDish != 0)
            {
                currentDish--;
				RefreshOutput(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentDish != dishes.Count() - 1)
            {
                currentDish++;
				RefreshOutput();              
            }
        }

		private void RefreshOutput()
		{
			label3.Text = dishes[currentDish].Name;
			label4.Text = dishes[currentDish].Price.ToString();
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).CheckState == CheckState.Checked)
            {
                selectedDishes.Add(dishes[currentDish]);
            }
            else if (((CheckBox)sender).CheckState == CheckState.Unchecked)
            {
                selectedDishes.Remove(dishes[currentDish]);
            }
        }

		private void btnMenu_Click(object sender, EventArgs e)
        {
            foreach (Dish d in selectedDishes)
            {
                MessageBox.Show("Блюдо " + d.Name);
            }
        }

		private void btnAdd_Click(object sender, EventArgs e)
        {
            DishForm dForm = new DishForm(this, Modes.Add);
            dForm.ShowDialog();
			RefreshOutput();
        }

		private void btnEdit_Click(object sender, EventArgs e)
        {
            DishForm dForm = new DishForm(this, Modes.Edit, dishes[currentDish]);
            dForm.ShowDialog();
			RefreshOutput();
        }

		private void btnRemove_Click(object sender, EventArgs e)
        {
            repository.Delete(dishes[currentDish]);
			if(currentDish > 0)
					currentDish--;
			RefreshOutput();
        }
	}
}
