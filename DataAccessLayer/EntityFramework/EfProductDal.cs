using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>,IProductDal
    {
        public List<Object> GetProductWithCategory()
        {
            CampContext context = new CampContext();
            var values=  context.Products.Select(
                x => new {

                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductStock= x.Stock,
                    Price = x.Price,
                    ProductDescription = x.ProductDescription,
                    CategoryName= x.Category.CategoryName

                }
               
                
                ).ToList();
            return values.Cast<Object>().ToList();

        }
    }
}
