using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Nettbutikk.DAL
{
    public class CustomerDAL : DAL.ICustomerDAL
    {
        public List<Customer> getAll()
        {
            return null; 
        }
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

