using App.DapperNew;
using App.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new BrandDbService().Create(new App.Domain.Brand { Name = textBox1.Text });
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BrandDbService().Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = new List<Brand>() { new BrandDbService().Select(int.Parse(textBox2.Text)) };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
var arr = new BrandDbService().SelectMultiple();

            gvBrands.DataSource = arr[0];

            gvModel.DataSource = arr[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                new BrandDbService().CreateModelUsingSp(new Model
                {
                    BrandId = 1,
                    Name = "ABC"
                });
                MessageBox.Show("Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                int returnOne = 0;
                new BrandDbService().CreateModelUsingSp(new Model
                {
                    BrandId = 1,
                    Name = "ABC"
                }, out id, out returnOne);

                MessageBox.Show($"out parameter:{id} \n return one : {returnOne}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                new BrandDbService().InsertBrandsAndModels(new Model
                {
                    Name = "MMM",
                    BrandId = 2
                }, new Brand { Name = "AAA" });
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
