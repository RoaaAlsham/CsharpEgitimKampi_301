using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsharpEgitimKampi_501_Dapper_Project.DTOs;
using Dapper;

namespace CsharpEgitimKampi_501_Dapper_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = DataConnectionString.dataConnection();


        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string bookCountQuery = "SELECT COUNT(*) FROM Books";
                int bookCount = await connection.QuerySingleAsync<int>(bookCountQuery);
                lblBookCount.Text = bookCount.ToString();
                string maxPriceQuery = "Select Title from Books where Price= (Select Max(Price) from Books)";
                string maxPriceTitle = await connection.QuerySingleAsync<string>(maxPriceQuery);
                lblMaxPrice.Text= maxPriceTitle;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error :{ex.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string query= "Select * from Books";
            Task<IEnumerable<BookResultDTO>> booktask = connection.QueryAsync<BookResultDTO>(query);
            IEnumerable<BookResultDTO> books = await booktask;
            dataGridView1.DataSource = books.ToList();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //btnDelete.Enabled = false;
            try
            {
                int id = int.Parse(txtBookId.Text);
                string query = "DELETE FROM Books WHERE BookId=@id";
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                //int affectedRows = connection.Execute(query, parameters);
                //if (affectedRows > 0)
                //{
                //    MessageBox.Show("Book deleted successfully.");
                //}
                //else
                //{
                //    MessageBox.Show("Failed to delete book.");
                //}
               int affectedRows= await connection.ExecuteAsync(query, parameters);
                if (affectedRows > 0)
                {
                    MessageBox.Show("Book deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete book.");
                }

            }
            catch (Exception ex) {
                MessageBox.Show($"Error :{ex.Message}");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBookId.Text);
            string query = "UPDATE Books SET Title=@title, Price=@price, Stock=@stock Where BookId=@id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@title", txtTitle.Text);
            parameters.Add("@price",decimal.Parse(txtPrice.Text));
            parameters.Add("@stock", int.Parse(txtStock.Text));
            int affectedRows =await connection.ExecuteAsync(query, parameters);
            if (affectedRows == 1)
            {
                MessageBox.Show("Book updated successfully.");
            }
            else if (affectedRows == 0)
            {
                MessageBox.Show("No book found with the specified ID.");
            }
            else {
                MessageBox.Show("Multiple books updated, which is unexpected.");
            }
        }

        private async  void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Books(Title,Price,Stock) VALUES (@title,@price,@stock)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", txtTitle.Text);
            parameters.Add("@price", decimal.Parse(txtPrice.Text));
            parameters.Add("@stock", int.Parse(txtStock.Text));
            int affectedRows =await connection.ExecuteAsync(query, parameters);
            if (affectedRows > 0)
            {
                MessageBox.Show("Book added successfully.");
            }
            else
            {
                MessageBox.Show("Failed to add book.");
            }
        }
    }
}
