using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SportsShopWebApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SportsShopWebApi.Controllers
{
    public class CustomerController : ApiController
    {

        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select * from dbo.Customers";
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
            using (var cmd = new SqlCommand(query,con))
                using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK,table);
        }

        public string Post(Customer customer)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Customers values('"+customer.CustomerName+@"','"+customer.CustomerPhoneNo+ @"','" + customer.CustomerAddress + @"','" + customer.CustomerEmailId+ @"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully to Customers";
            }
            catch(Exception ex)
            {
                return "Failed to Add. Something went wrong!"+ex;
            }

        }

        public string Put(Customer customer)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Customers set 
                CustomerName = '" + customer.CustomerName + @"'
                ,CustomerPhoneNo = '" + customer.CustomerPhoneNo + @"'
                ,CustomerAddress = '" + customer.CustomerAddress + @"'
                ,CustomerEmailId = '" + customer.CustomerEmailId + @"'
                where CustomerId = '" + customer.CustomerId + @"'
                ";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully to Customers";
            }
            catch (Exception ex)
            {
                return "Failed to Update. Something went wrong! "+ex;
            }

        }

        public string Delete(long id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from Customers where CustomerId = " + id;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully from Customers";
            }
            catch (Exception)
            {
                return "Failed to delete. Something went wrong!";
            }

        }

    }
}
