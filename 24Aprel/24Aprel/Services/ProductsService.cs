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
        public int AddProduct(Products product, EcommerDbContext dbContext) 
        {

            int count = 0;


                foreach (var item in dbContext.products.ToList())
                {
                    if (item.Name != product.Name)
                    {
                        if (product.Price >= 0)
                        {
                            if (product.Count >= 0)
                            {

                            count++;
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
                }return count;
            


        }
    }
}
