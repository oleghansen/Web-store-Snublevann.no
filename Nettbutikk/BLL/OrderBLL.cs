using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.BLL
{
    public class OrderBLL : BLL.IOrderBLL
    {
        private IOrderDAL _order;

        public OrderBLL()
        {
            _order = new OrderDAL();
        }

        public OrderBLL(IOrderDAL stub)
        {
            _order = stub;
        }

        public List<Order> getAllOrders(int? id)
        {
            ICustomerDAL _customer = new CustomerDAL();
            IProductDAL _product = new ProductDAL();
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
            return list;
        }

        public List<OrderLine> getAllOrderLinesOfOrder(int id)
        {
           /*  ICustomerDAL _customer = new CustomerDAL();
             ICustomerDAL _customer = new CustomerDAL();
            IProductDAL _product = new ProductDAL();
            List<OrderLine> orderlineslist = new List<OrderLine>();
            List<OrderLine> OLlist = _order.getAllOrderLinesOfOrder(id);

            foreach (var item in OLlist){

                var order = new Order()
                {
                     id = item.id,
                      orderdate = order.orderdate
                };

                orderlineslist.Add(new OrderLine()
                {
                    id = item.id,
                    productid = item.productid,
                    quantity = item.quantity,
                    product = _product.findProduct(item.productid),
                    orderid =  id,
                    order = 

                });

            }

                */
            return null;
        }

        public  Customer getCustomer(int id)
        {
            return null;
        }

        public Order getOne(int id)
        {
            return _order.getOrder(id);
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
