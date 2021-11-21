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
    public class ItemController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select * from dbo.Items";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Item item)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into Items values('" + item.ItemName + @"','" + item.ItemPrice + @"','" + item.ItemColor + @"','" + item.ItemSize + @"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully to Items";
            }
            catch (Exception ex)
            {
                return "Failed to Add. Something went wrong!" + ex;
            }

        }

        public string Put(Item item)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update Items set 
                ItemName = '" + item.ItemName + @"'
                ,ItemPrice = '" + item.ItemPrice + @"'
                ,ItemColor = '" + item.ItemColor + @"'
                ,ItemSize = '" + item.ItemSize + @"'
                where ItemId = '" + item.ItemId + @"'
                ";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully to Items";
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
                string query = @"delete from Items where ItemId = " + id;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SportsShopDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully from Items";
            }
            catch (Exception)
            {
                return "Failed to delete. Something went wrong!";
            }

        }
    }
}
