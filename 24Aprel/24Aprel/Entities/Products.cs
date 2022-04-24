using _24Aprel.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Data
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DiscountPrice { get; set; }
        public int Count { get; set; }
        public bool IsNew { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
    
}
