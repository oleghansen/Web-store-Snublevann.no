using Nettbutikk.Model;
using System;
using System.Collections.Generic;

namespace Nettbutikk.DAL
{
    public interface ICustomerDAL
    {
        List<Customer> getAll();

        List<Customer> getResult(string sc);

        bool update(int id, Customer updateUser, int adminid);
        bool validate(string email, byte[] hashedPassword);

        Customer findUser(String email);
        Customer getCustomer(int id);

        bool makeAdmin(int id, int adminid);

        bool revokeAdmin(int id, int adminid);
        bool delete(int id, int adminid);
    }
}
