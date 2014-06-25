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
    public partial class Form1 : Form
    {
        int currentDish;
        //BinaryRepository fileRepo;
		IRepository fileRepo;

        List<Dish> selectedDishes;

        public Form1()
        {
         
            InitializeComponent();

            selectedDishes = new List<Dish>();
			fileRepo = new XmlRepository("dishes.dat");//new BinaryRepository("dishes.dat");
            fileRepo.Add(new Dish("Кукруза", 12.6m));
            fileRepo.Add(new Dish("Картофель", 15.6m));
            fileRepo.Add(new Dish("Морковь", 14.6m));
            //fileRepo.OpenFile();
            label3.Text = fileRepo.GetDishes().ElementAt(0).Name;
            label4.Text = fileRepo.GetDishes().ElementAt(0).Price.ToString();
            currentDish = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentDish != 0)
            {
                currentDish--;
                label3.Text = fileRepo.GetDishes().ElementAt(currentDish).Name;
                label4.Text = fileRepo.GetDishes().ElementAt(currentDish).Price.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentDish != fileRepo.GetDishes().Count() - 1)
            {
                currentDish++;
                label3.Text = fileRepo.GetDishes().ElementAt(currentDish).Name;
                label4.Text = fileRepo.GetDishes().ElementAt(currentDish).Price.ToString();
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).CheckState == CheckState.Checked)
            {
                selectedDishes.Add(fileRepo.GetDishes().ElementAt(currentDish));
            }
            else if (((CheckBox)sender).CheckState == CheckState.Unchecked)
            {
                selectedDishes.Remove(fileRepo.GetDishes().ElementAt(currentDish));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Dish d in selectedDishes)
            {
                MessageBox.Show("Блюдо " + d.Name);
            }
        }
    }
}
