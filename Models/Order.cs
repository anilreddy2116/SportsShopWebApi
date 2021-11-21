using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsShopWebApi.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public string OrderDate { get; set; }
        public long CustomerId { get; set; }
        public long ItemId { get; set; }
    }
}