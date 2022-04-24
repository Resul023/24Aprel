using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
