using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = textName.Text;
            category.CategoryStatus = true;
            if (rdBtnPassive.Checked)
            {
                category.CategoryStatus = false;
            }
            _categoryService.TInsert(category);
            MessageBox.Show("Category Added");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Category> values = _categoryService.TGetAll();
            dataGridView1.DataSource = values;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            Category updatedOne = _categoryService.TGetById(id);
            updatedOne.CategoryName = textName.Text;
            updatedOne.CategoryStatus = true;
            if (rdBtnPassive.Checked)
            {
                updatedOne.CategoryStatus = false;
            }

            _categoryService.TUpdate(updatedOne);
            MessageBox.Show("Category Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            Category deletedOne = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedOne);
            MessageBox.Show("Category Deleted");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            Category category = _categoryService.TGetById(id);
            dataGridView1.DataSource = new List<Category> { category };
            ;
        }
    }
}
