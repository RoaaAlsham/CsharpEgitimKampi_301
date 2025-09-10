using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal) {

            _productDal = productDal;
        }
        public void TDelete(Product entity)
        {
            _productDal.delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Object> TGetProductWithCategory()
        {
           return _productDal.GetProductWithCategory();
        }

        public void TInsert(Product entity)
        {
            _productDal.insert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productDal.update(entity);
        }
    }
}
