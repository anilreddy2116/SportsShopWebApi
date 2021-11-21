using SportsShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsShopWebApi.Controllers
{
    public class OrderController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select * from dbo.Orders";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(Order order)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Orders values('" + order.OrderDate + @"','" + order.CustomerId + @"','" + order.ItemId + @"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully to Orders";
            }
            catch (Exception)
            {
                return "Failed to Add. Something went wrong!";
            }

        }

        public string Put(Order order)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Orders set 
                Orderdate = '"+order.OrderDate + @"'
                ,CustomerId = '" + order.CustomerId + @"'
                ,ItemId = '" + order.ItemId + @"'
                where OrderId = '"+order.OrderId+@"'
                ";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully to Orders";
            }
            catch (Exception)
            {
                return "Failed to Update. Something went wrong!";
            }

        }

        public string Delete(long id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from Orders where OrderId = " + id;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully from Orders";
            }
            catch (Exception)
            {
                return "Failed to delete. Something went wrong!";
            }

        }
    }
}
