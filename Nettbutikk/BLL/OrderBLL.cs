using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.BLL
{
    public class OrderBLL : BLL.IOrderBLL
    {
        private IOrderDAL _order;
        private IProductDAL _product;
        private ICustomerDAL _customer;

        public OrderBLL()
        {
            _order = new OrderDAL();
            _product = new ProductDAL();
            _customer = new CustomerDAL();
        }

        public OrderBLL(IOrderDAL stub)
        {
            _order = stub;
            _product = new ProductDALStub();
            _customer = new CustomerDALStub();
        }

        public List<Order> getAllOrders(int? id)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            List<Order> allOrders = _order.getAllOrders(id);
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
                        quantity = OrderLineItems .quantity,
                        product = _product.findProduct(OrderLineItems.productid),
                        orderid =  OrderLineItems.orderid 
                           
                    });
                }
                list.Add(new Order() 
                {
                    id = item.id,
                    orderdate = item.orderdate,
                    customerid = item.customerid ,
                    customer =  _customer.getCustomer(item.customerid),
                    orderLine = orderlineslist
                });
            }
            sw.Stop();

            Debug.WriteLine("get all i BLL Elapsed={0}", sw.Elapsed);
            //getall i BLL Elapsed=00:00:13.3913756


            return list;
        }

        public int getNumItems(Order o)
        {
            var num = 0;
            foreach(var item in o.orderLine)
            {
                num += item.quantity;
            }
            return num;
        }

        public int getSum(Order o)
        {
            var sum = 0;
            foreach (var item in o.orderLine )
            {
                sum += item.quantity * item.product.price;
            }
            return sum;
        }

        public double getExmva(int sum)
        {
            return sum * 0.8;
        }

        public double getMva(int sum)
        {
            return sum * 0.2;
        }

    }
}
