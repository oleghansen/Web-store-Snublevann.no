using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class CustomerDALStub : DAL.ICustomerDAL
    {
        public bool add(Customer inCustomer, byte[] hashedPassword)
        {
            return true;
        }

        public Customer findCustomer(String email)
        {
            return null;
        }

        public bool validate(String email, byte[] hashedPassword)
        {
            return false;
        }

        public bool update(int id, Customer updateUser)
        {
            return false;
        }

        public bool updatePw(int id, byte[] newPassword)
        {
            return false;

        }

        public bool checkEmail(string email, int? id)
        {

            return false;
        }
    }
}
