using Nettbutikk.Model;
using System;

namespace Nettbutikk.DAL
{
    interface ICustomerDAL
    {
        bool add(Customer inCustomer, byte[] hashedPassword);
        bool checkEmail(string email, int? id);
        Customer findCustomer(string email);
        bool update(int id, Customer updateUser);
        bool updatePw(int id, byte[] newPassword);
        bool validate(string email, byte[] hashedPassword);
    }
}
