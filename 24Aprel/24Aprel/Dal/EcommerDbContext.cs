using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _24Aprel.Dal
{
    public class EcommerDbContext:DbContext
    {
        public DbSet<Products> products { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Comment> comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0UDOH5O;Database=Ecommerce;Trusted_Connection=TRUE");
        }
    }
}
