using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsShopWebApi.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public long ItemPrice { get; set; }
        public string ItemColor { get; set; }
        public int ItemSize { get; set; }
    }
}