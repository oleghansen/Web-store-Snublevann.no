using System;
using Nettbutikk.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public class CustomerBLL
    {
        private ICustomerDAL _customer;

        public CustomerBLL()
        {
            _customer = new CustomerDAL();
        }
        public CustomerBLL(ICustomerDAL stub)
        {
            _customer = stub;
        }

        public List<Customer> getAll()
        {
            List<Customer> allCustomers = _customer.getAll();
            return allCustomers;
        }
    }
}
