using System;
using Nettbutikk.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public class CustomerBLL : BLL.ICustomerBLL
    {
        private ICustomerDAL _customer;

        public CustomerBLL()
        {
            _customer = new CustomerDAL();
        }
        public CustomerBLL(ICustomerDAL stub)
        {
            _customer = stub;
        }

        public List<Customer> getAll()
        {
            List<Customer> allCustomers = _customer.getAll();
            return allCustomers;
        }

        public List<Customer> getResult(string s)
        {
            List<Customer> allCustomers = _customer.getResult(s);
            return allCustomers;
        }

        public Customer findUser(String email)
        {
            return _customer.findUser(email);
            
        }

        public bool validate(String email, byte[] hashedpassword)
        {
            return _customer.validate(email,hashedpassword);
        }

        public byte[] makeHash(String password)
        {
            byte[] inData, outData;
            var algorithm = System.Security.Cryptography.SHA256.Create();
            inData = System.Text.Encoding.ASCII.GetBytes(password);
            outData = algorithm.ComputeHash(inData);
            return outData;
        }

        public bool makeAdmin(int id)
        {
            return _customer.makeAdmin(id);
        }

        public bool revokeAdmin(int id)
        {
            return _customer.revokeAdmin(id);
        }

       public Customer logIn(String email, String password)
        {

            byte[] hashpassword = makeHash(password);
            bool ok = validate(email, hashpassword);
            if (ok)
            {
                Customer c = findUser(email);
                return c;
            }
            return null;
           
        }

       public List<Order> getAllOrdersbyCust(int id)
       {
           IOrderDAL _order = new OrderDAL();
           IProductDAL _product = new ProductDAL();
           List<Order> allOrders = _order.getAllOrdersbyCust(id);
           List<Order> list = new List<Order>();

           foreach (var item in allOrders)
           {
               List<OrderLine> orderlineslist = new List<OrderLine>();
               List<OrderLine> OLlist = _order.getAllOrderLinesOfOrder(item.id);
               foreach (var OrderLineItems in OLlist)
               {
                   orderlineslist.Add(new OrderLine()
                   {
                       id = OrderLineItems.id,
                       productid = OrderLineItems.productid,
                       quantity = OrderLineItems.quantity,
                       product = _product.findProduct(OrderLineItems.productid),
                       orderid = OrderLineItems.orderid


                   });
               }
               list.Add(new Order()
               {
                   id = item.id,
                   orderdate = item.orderdate,
                   customerid = item.customerid,
                   customer = _customer.getCustomer(item.customerid),
                   orderLine = orderlineslist
               });
           }
           return list;
       }

    }
}
