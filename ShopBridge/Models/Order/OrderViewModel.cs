using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class OrderViewModel
    {
        
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string OrderCity { get; set; }
        public string OrderCountry { get; set; }
        public string OrderAddress { get; set; }

        public string OrderDescription { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}