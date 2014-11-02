using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Nettbutikk.DAL
{
    public class CustomerDAL : DAL.ICustomerDAL
    {
        public List<Customer> getAll()
        {
            try
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
            catch(Exception e)
            {
                writeToFile(e);
                return null; 
            }
        }

        public List<Customer> getResult(string searchString)
        {
            try
            {
                var db = new DatabaseContext();

                List<Customer> users = db.Customers.Select(p => new Customer()
                {
                    id = p.Id,
                    firstname = p.Firstname,
                    lastname = p.Lastname,
                    address = p.Address,
                    email = p.Email,
                    postalcode = p.PostalareasId.ToString(),
                    postalarea = p.Postalareas.Postalarea,
                    phonenumber = p.Phonenumber

                }).Where(p => p.firstname.ToUpper().Contains(searchString.ToUpper())
                                || p.lastname.ToUpper().Contains(searchString.ToUpper())).ToList();
                foreach (var u in users)
                {
                    u.postalcode = normalizePostalcode(int.Parse(u.postalcode));
                }
                return users;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null;
            }
        }

        public Customer getCustomer(int id)
        {
            try
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
            catch(Exception e)
            {
                writeToFile(e);
                return null;
            }
        }

        public String getPostalarea(int id)
        {
            try
            {
                var db = new DatabaseContext();
                var postalarea = (Postalareas)db.Postalareas.FirstOrDefault(p => p.PostalareasId == id);
                return postalarea.Postalarea;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null;
            }
        }

        public Customer findUser(String email)
        {
            try
            {
                var db = new DatabaseContext();
                Customers userFound = db.Customers.FirstOrDefault(u => u.Email == email);
                Customer c = new Customer();
                c.id = userFound.Id;
                c.firstname = userFound.Firstname;
                c.lastname = userFound.Lastname;
                c.email = userFound.Email;
                c.phonenumber = userFound.Phonenumber;
                c.postalcode = normalizePostalcode(userFound.PostalareasId);
                c.postalarea = db.Postalareas.Find(userFound.PostalareasId).Postalarea;
                c.address = userFound.Address;
                c.hashpassword = userFound.Password;
                c.admin = true;
                return c;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null;
            }
        }
        public bool validate(String email, byte[] hashedPassword)
        {
            try
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
            }
            catch(Exception e)
            {
                writeToFile(e);
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
            catch (Exception e)
            {
                writeToFile(e);
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
            catch (Exception e)
            {
                writeToFile(e);
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
            catch (Exception e)
            {
                writeToFile(e);
                return false;
            }

        }

        public bool update(int id, Customer updateUser, int adminid)
        {
            var db = new DatabaseContext();
            try
            {
                Customers cust = db.Customers.FirstOrDefault(u => u.Id == id);
                cust.Firstname = updateUser.firstname;
                cust.Lastname = updateUser.lastname;
                cust.Email = updateUser.email;
                cust.Phonenumber = updateUser.phonenumber;
                cust.Address = updateUser.address;
                cust.PostalareasId = Convert.ToInt16(updateUser.postalcode);

                var existPostalcode = db.Postalareas.Find(Convert.ToInt16(updateUser.postalcode));

                if (existPostalcode == null)
                {
                    var newPostalarea = new Postalareas()
                    {
                        PostalareasId = Convert.ToInt16(updateUser.postalcode),
                        Postalarea = updateUser.postalarea
                    };
                    cust.Postalareas = newPostalarea;
                }
                db.SaveChanges(adminid);
                return true;
            }
            catch (Exception e)
            {
                writeToFile(e);
                return false;
            }
        }

        private String normalizePostalcode(int postalcode)
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


        private void writeToFile(Exception e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"nettbutikkFeiLogg.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----------   " + DateTime.Now.ToString() + "   --------------");
                    writer.WriteLine("");
                    writer.WriteLine("Message: " + e.Message + Environment.NewLine
                       + "Stacktrace: " + e.StackTrace + Environment.NewLine);
                }
            }
            catch (IOException ioe)
            {
                Debug.WriteLine(ioe.Message);
            }
            catch (UnauthorizedAccessException uae)
            {
                Debug.WriteLine(uae.Message);
            }
        }
    }
}

