using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
namespace PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryservice;
        public FrmProduct()
        {
            InitializeComponent();
            productService = new ProductManager(new EfProductDal());
            categoryservice = new CategoryManager(new EfCategoryDal());
           

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            List<Category> categories = categoryservice.TGetAll();
            cbCategory.DataSource = categories;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryId";
        }
        
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = productService.TGetAll();
            dataGridView1.DataSource = values;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = productService.TGetProductWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var Product = productService.TGetById(id);
            productService.TDelete(Product);
            MessageBox.Show("Product Deleed");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = txtProductName.Text;
            product.Stock = int.Parse(txtStock.Text);
            product.Price = decimal.Parse(txtPrice.Text);
            product.ProductDescription = txtDescription.Text;
            //find category id and set it to product
            product.CategoryId = (int)cbCategory.SelectedValue;
            productService.TInsert(product);
            MessageBox.Show("Product Added");   

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            List<Product> product = new List<Product>() { productService.TGetById(id) };
            dataGridView1.DataSource = product;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var product = productService.TGetById(id);
            product.ProductName = txtProductName.Text;
            product.Stock = int.Parse(txtStock.Text);
            product.Price = decimal.Parse(txtPrice.Text);
            product.ProductDescription = txtDescription.Text;
            //find category id and set it to product
            product.CategoryId = (int)cbCategory.SelectedValue;
            productService.TUpdate(product);
            MessageBox.Show("Product Updated"); 

        }
    }
}
