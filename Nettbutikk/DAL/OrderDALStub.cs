using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class OrderDALStub : DAL.IOrderDAL       
    {
        public List<Order> getAllOrders(int? id)
        {
            List<Order> list = new List<Order>();

            if (id == 298423)
            {
                var order = new Order()
                {

                    id = 298423,
                    customerid = 1,
                    orderdate = DateTime.Now
                    
                };
                list.Add(order);
                return list;
            }

            var order0 = new Order()
            {
                 
                id = 298423,
                customerid = 1,   
                orderdate = DateTime.Now
            };
            var order1 = new Order()
            {

                id = 298424,
                customerid = 2,
                orderdate = DateTime.Now
            };
            var order2 = new Order()
            {

                id = 298425,
                customerid = 4,
                orderdate = DateTime.Now
            };
            var order3 = new Order()
            {

                id = 298426,
                customerid = 5,
                orderdate = DateTime.Now
            };
            var order4 = new Order()
            {

                id = 298427,
                customerid = 6,
                orderdate = DateTime.Now
            };
            var order5 = new Order()
            {

                id = 298428,
                customerid = 7,
                orderdate = DateTime.Now 
            };
            list.Add(order0);
            list.Add(order1);
            list.Add(order2);
            list.Add(order3);
            list.Add(order4);
            list.Add(order5);
            
            return list;
        }

        public List<Order> getAllOrdersbyCust(int id)
        {
            List<Order> list = new List<Order>();

            var order = new Order()
            {

                id = 298423,
                customerid = 1,
                orderdate = DateTime.Now
            };
            var order1 = new Order()
            {

                id = 298424,
                customerid = 2,
                orderdate = DateTime.Now
            };
            var order2 = new Order()
            {

                id = 298425,
                customerid = 3,
                orderdate = DateTime.Now
            };
            list.Add(order);
            list.Add(order1);
            list.Add(order2);
            return list;
        }
        public List<OrderLine> getAllOrderLinesOfOrder(int id)
        {
            List<OrderLine> olList = new List<OrderLine>();

            if (id == 298423)
            {
                olList.Add( new OrderLine()
                {
                    id = 1,
                    productid = 1,
                    quantity = 3,
                    orderid = 298423,
                });
                olList.Add(new OrderLine()
                {
                    id = 2,
                    productid = 2,
                    quantity = 4,
                    orderid = 298423,
                   
                });

                return olList;
                 
            }
            
            var orderline = new OrderLine()
            {
                id = 1,
                productid = 1,
                quantity = 3,
                orderid = 298423,
                

            };
            var orderline1 = new OrderLine()
            {
                id = 2,
                productid = 2,
                quantity = 4,
                orderid = 298424,


            };
            var orderline2 = new OrderLine()
            {
                id = 3,
                productid = 3,
                quantity = 5,
                orderid = 298425,


            };
            olList.Add(orderline);
            olList.Add(orderline1);
            olList.Add(orderline2);

            
            return olList;
        }

       
       
    }
}
