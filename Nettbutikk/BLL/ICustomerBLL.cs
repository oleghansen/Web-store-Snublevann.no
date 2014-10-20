using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface ICustomerBLL
    {
        List<Customer> getAll();
        bool validate(String email, byte[] hashedPassword);

        byte[] makeHash(String password);

        Customer findUser(String email);
        Customer logIn(String email, String password);
    }
}
