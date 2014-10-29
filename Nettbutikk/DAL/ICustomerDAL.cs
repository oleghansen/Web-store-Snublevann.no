using Nettbutikk.Model;
using System;
using System.Collections.Generic;

namespace Nettbutikk.DAL
{
    public interface ICustomerDAL
    {
        List<Customer> getAll();

        List<Customer> getResult(string sc);

        bool add(Customer inCustomer, byte[] hashedPassword);
        bool checkEmail(string email, int? id);
        Customer findCustomer(string email);
        bool update(int id, Customer updateUser);
        bool updatePw(int id, byte[] newPassword);
        bool validate(string email, byte[] hashedPassword);

        Customer findUser(String email);
        Customer getCustomer(int id);

        bool makeAdmin(int id, int adminid);

        bool revokeAdmin(int id, int adminid);
    }
}
