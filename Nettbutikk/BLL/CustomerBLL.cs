using System;
using Nettbutikk.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public class CustomerBLL : BLL.ICustomerBLL
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

        public Customer findUser(String email)
        {
            return _customer.findUser(email);
        }

        public bool validate(String email, byte[] hashedpassword)
        {
            return _customer.validate(email,hashedpassword);
        }

        public byte[] makeHash(String password)
        {
            byte[] inData, outData;
            var algorithm = System.Security.Cryptography.SHA256.Create();
            inData = System.Text.Encoding.ASCII.GetBytes(password);
            outData = algorithm.ComputeHash(inData);
            return outData;
        }

       public Customer logIn(String email, String password)
        {

            byte[] hadhpassword = makeHash(password);
            bool ok = validate(email, hadhpassword);
            if (ok)
            {
                return findUser(email);
            }
            return null;
           
        }

    }
}
