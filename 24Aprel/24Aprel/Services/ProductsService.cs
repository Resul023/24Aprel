using _24Aprel.Dal;
using ClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24Aprel.Services
{
    public class ProductsService
    {
        public EcommerDbContext AddProduct(Products product) 
        {

            EcommerDbContext dbcontext = new EcommerDbContext();


                foreach (var item in dbcontext.products.ToList())
                {
                    if (item.Name != product.Name)
                    {
                        if (product.Price >= 0)
                        {
                            if (product.Count >= 0)
                            {
                            dbcontext.products.Add(product);
                            dbcontext.SaveChanges();
                            
                            }
                            else
                            {
                                 throw new CountIsNotTrue("Count can not be minus");
                            
                            }
                        }
                        else
                        {
                            throw new PriceIsNotTrue("Price can not be minus");
                        }

                    }
                    else
                    {
                        throw new ProductIsAlreadyExist("This produc is exist");
                    
                    }
                }return dbcontext;
            


        }
    }
}
