using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace Nettbutikk.DAL
{
    public class OrderDAL : DAL.IOrderDAL
    {
        public List<OrderLine> getAllOrderLinesOfOrder(int id)
        {
            try
            {
                var db = new DatabaseContext();
                List<OrderLine> lines = db.OrderLines.Select(item => new OrderLine()
                {
                    id = item.Id,
                    orderid = item.OrdersId,
                    productid = item.ProductsId,
                    quantity = item.Quantity,
                }).Where(item => item.orderid == id).ToList();

                return lines;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null;
            }
        }
              

        public List<Order> getAllOrders(int? id)
        {

            try
            {
                Stopwatch sw = new Stopwatch();

                sw.Start();
                var db = new DatabaseContext();
                List<Order> lines;
                if (id != null)
                    lines = db.Orders.Select(item => new Order()
                    {
                        id = item.Id,
                        orderdate = item.OrderDate,
                        customerid = item.CustomersId
                    }).Where(item => item.id == id).ToList();
                else
                    lines = db.Orders.Select(item => new Order()
                    {
                        id = item.Id,
                        orderdate = item.OrderDate,
                        customerid = item.CustomersId
                    }).ToList();
                sw.Stop();

                Debug.WriteLine("get allorders; Elapsed={0}", sw.Elapsed);
                //get allorders; Elapsed=00:00:00.0457881
                return lines;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null; 
            }
        }

        public List<Order> getAllOrdersbyCust(int id)
        {
            try
            {
                var db = new DatabaseContext();
                List<Order> lines = db.Orders.Select(item => new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate,
                    customerid = item.CustomersId
                }).Where(o => o.customerid == id).ToList();

                return lines;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null;
            }
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