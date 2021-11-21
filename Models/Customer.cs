using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsShopWebApi.Models
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }

        public long CustomerPhoneNo { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmailId { get; set; }

    }
}