﻿using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk
{
    public class DBCustomer
    {
        public bool add(Customer inCustomer, byte[] hashedPassword)
        {
            var newCustomer = new Customers()
            {
                Firstname = inCustomer.firstname,
                Lastname = inCustomer.lastname,
                Address = inCustomer.address,
                PostalareasId = Convert.ToInt16(inCustomer.postalcode),
                Username = inCustomer.username,
                Password = hashedPassword,
                Phonenumber = inCustomer.phonenumber,
                Email = inCustomer.email
            };

            var db = new DatabaseContext();
            try
            {
                var existPostalcode = db.Postalareas.Find(inCustomer.postalcode);

                if(existPostalcode == null )
                {
                    var newPostalarea = new Postalareas()
                    {
                        PostalareasId = inCustomer.postalcode,
                        Postalarea = inCustomer.postalarea
                    };
                    newCustomer.Postalareas = newPostalarea;
                }
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }
    
        public Customer findCustomer(String username)
        {
            var db = new DatabaseContext();
            Customers userFound =  db.Customers.FirstOrDefault(u => u.Username == username);
            Customer c = new Customer();
            c.id = userFound.Id;
            c.firstname = userFound.Firstname;
            c.lastname = userFound.Lastname;
            c.email = userFound.Email;
            c.phonenumber = userFound.Phonenumber;
            c.address = userFound.Address;
            c.postalcode = userFound.PostalareasId;
            c.postalarea = db.Postalareas.Find(userFound.PostalareasId).Postalarea;
            c.username = userFound.Username;
            c.hashpassword = userFound.Password;
            

            return c;
        }

        public bool validate(String username, byte[] hashedPassword)
        {
            var db = new DatabaseContext();

            try
            {
                Customers validated = db.Customers.FirstOrDefault(u => u.Password == hashedPassword && u.Username == username);
                if (validated == null)
                    return false;
                else
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool update(int id, Customer updateUser, byte[] hashpassword)
        {
            var db = new DatabaseContext();
            try
            {
                var existPostalcode = db.Postalareas.Find(updateUser.postalcode);

                if (existPostalcode == null)
                {
                    var newPostalarea = new Postalareas()
                    {
                        PostalareasId = updateUser.postalcode,
                        Postalarea = updateUser.postalarea
                    };
                   
                }
                               
                     db.Customers.Update(c => new Customers() { Id = id },
                                 c => c.Firstname == updateUser.firstname && c.Lastname == updateUser.lastname && 
                                 c.Address == updateUser.address && c.Address == updateUser.address && c.Address == updateUser.address &&
                                 c.Postalcode == updateUser.postalcode && c.Username == updateUser.username && c.Password == hashpassword &&
                                 c.Phonenumber == updateUser.phonenumber && c.Email == updateUser.email && c.Postalareas = Postalarea &&
                                 c.Orders == updateUser.Orders);    
                
            }
            catch (Exception fail)
            {
                return false;
            }
        }
    }
}

