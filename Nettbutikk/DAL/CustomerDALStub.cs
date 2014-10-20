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
        public List<Customer> getAll()
        {
            var cust = new Customer()
            {
                id = 1,
                firstname = "Gunnar",
                lastname = "Hansen",
                address = "Golia",
                email = "klin@kokkos.no",
                postalarea = "Gollie",
                postalcode = "1232",
                phonenumber = "94499449",
                password = "tullball123"

            };
            List<Customer> custList = new List<Customer>();
            custList.Add(cust);
            return custList;
        }
        public bool add(Customer inCustomer, byte[] hashedPassword)
        {
            return true;
        }

        public Customer findCustomer(String email)
        {
            return null;
        }

        public Customer findUser(String email)
        {
            Customer c = new Customer();
            c.id = 1;
            c.email = "hei";
            c.password = "yo";
            return c;

        }

        public bool validate(String email, byte[] hashedPassword)
        {
            Customer c = new Customer();
            c.email = "Hei";
            c.hashpassword = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("yo"));

            if (c.email.Equals(email) && c.hashpassword.Equals(hashedPassword))
            {
                return true;
            }

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
