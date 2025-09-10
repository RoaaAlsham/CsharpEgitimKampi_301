using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.delete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.FirstName.Length>=2 && entity.LastName.Length>=2 
                && entity.Address.Length>=3 
                && entity.PhoneNumber.Length==11) {
                // add customer to database
                _customerDal.insert(entity);

            } else {

                //throw an error message
                }
            }
        public void TUpdate(Customer entity)
        {
            //throw new NotImplementedException();
            _customerDal.update(entity);
        }
    }
}
