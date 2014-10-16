using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Nettbutikk.DAL
{
    public class CustomerDAL
    {
        private DatabaseContext _db;
        public CustomerDAL()
        {
            _db = new DatabaseContext();
        }
        public CustomerDAL(DatabaseContext stub)
        {
            _db = stub;
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

