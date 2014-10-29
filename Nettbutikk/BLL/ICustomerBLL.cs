using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface ICustomerBLL
    {
        List<Customer> getAll();

        List<Customer> getResult(string sc);
        bool validate(String email, byte[] hashedPassword);
        bool addCustomer(Customer c, int adminid);

        byte[] makeHash(String password);

        Customer findUser(String email);
        Customer findCustomer(int id);
        Customer logIn(String email, String password);

        bool makeAdmin(int id, int adminid);

        bool revokeAdmin(int id, int adminid);
        bool delete(int id, int adminid);
        List<Order> getAllOrdersbyCust(int id);
    }
}
