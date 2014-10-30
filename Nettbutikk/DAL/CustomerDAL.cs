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
            var db = new DatabaseContext();
            List<Customer> customers = db.Customers.Select(item => new Customer()
            {
                id = item.Id,
                firstname = item.Firstname,
                lastname = item.Lastname,
                address = item.Address,
                email = item.Email,
                postalcode = item.PostalareasId.ToString(),
                postalarea = item.Postalareas.Postalarea,
                phonenumber = item.Phonenumber,
                admin = item.Admin
            }).ToList();

            foreach (var i in customers)
            {
                i.postalcode = normalizePostalcode(int.Parse(i.postalcode)); 
            }

            return customers;
        }

        public List<Customer> getResult(string searchString)
        {
            var db = new DatabaseContext();
            
            List<Customer> users = db.Customers.Select(p => new Customer() 
            {
                id = p.Id,
                firstname = p.Firstname,
                lastname = p.Lastname,
                address = p.Address,
                email = p.Email,
                postalcode = normalizePostalcode(p.PostalareasId),
                postalarea = db.Postalareas.Find(p.PostalareasId).Postalarea,
                phonenumber = p.Phonenumber

            }).Where(p => p.firstname.ToUpper().Contains(searchString.ToUpper())
                            || p.lastname.ToUpper().Contains(searchString.ToUpper())).ToList();
            foreach (var u in users)
            {
                u.postalcode = normalizePostalcode(int.Parse(u.postalcode));
            }
            return users;
        }

        public Customer getCustomer(int id)
        {
            var db = new DatabaseContext();
            Customers cust = (Customers)db.Customers.FirstOrDefault(c => c.Id == id);
            Customer customer = new Customer();
             
            customer.id = cust.Id;
            customer.firstname = cust.Firstname;
            customer.lastname = cust.Lastname;
            customer.phonenumber = cust.Phonenumber;
            customer.email = cust.Email;
            customer.address = cust.Address;
            customer.hashpassword = cust.Password;
            customer.admin = cust.Admin; 
            customer.postalarea = getPostalarea(cust.PostalareasId);
            customer.postalcode = normalizePostalcode(cust.PostalareasId);

            return customer;
        }

        public String getPostalarea(int id)
        {
            var db = new DatabaseContext();
            var postalarea = (Postalareas)db.Postalareas.FirstOrDefault(p => p.PostalareasId == id);
            return postalarea.Postalarea;
        }


        public bool add(Customer inCustomer, byte[] hashedPassword, int adminid)
        {
            var newCustomer = new Customers()
            {
                Firstname = inCustomer.firstname,
                Lastname = inCustomer.lastname,
                Address = inCustomer.address,
                PostalareasId = Convert.ToInt16(inCustomer.postalcode),
                Password = hashedPassword,
                Phonenumber = inCustomer.phonenumber,
                Email = inCustomer.email,
                Admin = false
            };

            var db = new DatabaseContext();
            try
            {
                var existPostalcode = db.Postalareas.Find(Convert.ToInt16(inCustomer.postalcode));

                if (existPostalcode == null)
                {
                    var newPostalarea = new Postalareas()
                    {
                        PostalareasId = Convert.ToInt16(inCustomer.postalcode),
                        Postalarea = inCustomer.postalarea
                    };
                    newCustomer.Postalareas = newPostalarea;
                }
                db.Customers.Add(newCustomer);
                db.SaveChanges(adminid);
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }

        public Customer findUser(String email)
        {
            var db = new DatabaseContext();
            Customers userFound = db.Customers.FirstOrDefault(u => u.Email == email);
            Customer c = new Customer();
            c.id = userFound.Id;
            c.email = userFound.Email;
            c.hashpassword = userFound.Password;
            c.admin = true;
            return c;

        }
        public bool validate(String email, byte[] hashedPassword)
        {
            var db = new DatabaseContext();
            Customers userFound = db.Customers.FirstOrDefault(u => u.Email == email);

            if (userFound != null)
            {
                if (email.Equals(userFound.Email) && Enumerable.SequenceEqual(hashedPassword, userFound.Password))
                {
                    if (userFound.Admin == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool makeAdmin(int id, int adminid)
        {
            var db = new DatabaseContext();
            try
            {
                Customers cust = db.Customers.FirstOrDefault(u => u.Id == id);
                cust.Admin = true;
                db.SaveChanges(adminid);
                return true;
            }
            catch (Exception fail)
            {
                //Skriv feil til fil
                return false;

            }

        }

        public bool revokeAdmin(int id, int adminid)
        {
            var db = new DatabaseContext();
            try
            {
                Customers cust = db.Customers.FirstOrDefault(u => u.Id == id);
                cust.Admin = false;

                db.SaveChanges(adminid);

                return true;
            }
            catch (Exception fail)
            {
                //Skriv feil til fil
                return false;

            }
        }

        public bool delete(int id, int adminid)
        {
            var db = new DatabaseContext();
            try
            {
                Customers cust = db.Customers.FirstOrDefault(u => u.Id == id);
                db.Customers.Remove(cust);
                db.SaveChanges(adminid);
                return true;
            }
            catch (Exception fail)
            {
                //Skriv feil til fil
                return false;

            }

        }

        public bool update(int id, Customer updateUser)
        {
            return false;
        }

        public String normalizePostalcode(int postalcode)
        {
            String normPostalcode = postalcode.ToString();
            if (postalcode < 1000)
            {
                normPostalcode = "0" + postalcode.ToString();
                if (postalcode < 100)
                {
                    normPostalcode = "00" + postalcode.ToString();
                    if (postalcode < 10)
                        normPostalcode = "000" + postalcode.ToString();
                }

            }
            return normPostalcode;
        }
        

    }
}

