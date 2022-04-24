using System;
using System.Linq;
using _24Aprel.Dal;
using _24Aprel.Services;
using ClassLibrary;
using ClassLibrary.Data;

namespace _24Aprel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("1-Add to product");
                Console.WriteLine("2-Search on product");
                Console.WriteLine("3-Look product comment with ProductId");
                Console.WriteLine("4-Look user comment with UserId");
                Console.WriteLine("5-Remove comment with CommentId");
                Console.WriteLine("6-Look products average price");
                Console.WriteLine("7-Look Comments between 2 dates given");
                Console.WriteLine("8-End process");
                int answer;
                string answerTool;
                do
                {

                    answerTool = Console.ReadLine();

                } while (!int.TryParse(answerTool, out answer));

                switch (answer)
                {
                    case 1:
                        string name;
                        do
                        {
                            Console.WriteLine("Write product name");
                            name = Console.ReadLine();

                        } while (String.IsNullOrWhiteSpace(name));
                        decimal price;
                        string priceTool;
                        do
                        {
                            Console.WriteLine("Write Price");

                            priceTool = Console.ReadLine();

                        } while (!decimal.TryParse(priceTool, out price));
                        int discountedPrice;
                        string discountedPriceTool;
                        do
                        {
                            Console.WriteLine("Write discounted price");
                            discountedPriceTool = Console.ReadLine();

                        } while (!int.TryParse(discountedPriceTool, out discountedPrice));
                        int count;
                        string countTool;
                        do
                        {
                            Console.WriteLine("Product count");
                            countTool = Console.ReadLine();

                        } while (!int.TryParse(countTool, out count));
                        bool checkTwo = true;
                        bool productIsNew = true;
                        while (checkTwo)
                        {
                            Console.WriteLine("Is it product new Y/N");
                            string answerTwo = Console.ReadLine();
                            if (answerTwo == "Y" || answerTwo == "y")
                            {
                                checkTwo = false;
                            }
                            else if (answerTwo == "N" || answerTwo == "n")
                            {
                                productIsNew = false;
                                checkTwo = false;
                            }
                            else
                            {
                                checkTwo = true;
                            }
                        }
                        
                        Products newProduct = new Products();
                        newProduct.Name = name;
                        newProduct.Price = price;
                        newProduct.DiscountPrice = discountedPrice;
                        newProduct.Count = count;
                        newProduct.IsNew = productIsNew;
                        newProduct.CreatedAt = DateTime.Now;


                        EcommerDbContext dbContext = new EcommerDbContext();
                        ProductsService newServices = new ProductsService();
                        if (newServices.AddProduct(newProduct, dbContext)>0)
                        {
                            dbContext.products.Add(newProduct);
                        }
                        
                        
                            

                        break;
                    case 2:
                        
                        Console.WriteLine("Write product name");
                        string namePro = Console.ReadLine();
                         dbContext = new EcommerDbContext();
                        int countProName = 0;
                        foreach (var item in dbContext.products.ToList())
                        {
                            if (item.Name.Contains(namePro))
                            {
                                Console.WriteLine(item.Name);
                                countProName++;
                            }
                            


                        }
                        if (countProName == 0)
                        {
                            Console.WriteLine("This product is not exist");
                        }
     
                        break;
                    case 3:
                        Console.WriteLine("Write productId");
                        int productId = Convert.ToInt32(Console.ReadLine());
                         dbContext = new EcommerDbContext();
                        foreach (var item in dbContext.comments.Where(x => x.ProductId == productId))
                        {
                            Console.WriteLine(item.Text);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Write UserId");
                        int userId = Convert.ToInt32(Console.ReadLine());
                         dbContext = new EcommerDbContext();
                        foreach (var item in dbContext.comments.Where(x => x.UserId == userId))
                        {
                            Console.WriteLine(item.Text);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Write commentId");
                        int commentId = Convert.ToInt32(Console.ReadLine());
                        dbContext = new EcommerDbContext();
                        foreach (var item in dbContext.comments.Where(x => x.Id == commentId))
                        {
                            dbContext.comments.Remove(item);
                        }
                        break;
                    case 6:
                        Console.WriteLine("All products average price");
                        decimal sum = 0;
                         dbContext = new EcommerDbContext();
                        foreach (var item in dbContext.products.ToList())
                        {
                            sum += item.Price*item.Count;
                        }
                        Console.WriteLine(sum/ dbContext.products.Count());
                        break;
                    case 7:
                        Console.WriteLine("Write Start date:");
                        DateTime timeStart = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Write End date:");
                        dbContext = new EcommerDbContext();
                        DateTime timeEnd = Convert.ToDateTime(Console.ReadLine());
                        foreach (var item in dbContext.comments.Where(x => x.CreatedAt> timeStart && x.CreatedAt< timeEnd))
                        {
                            Console.WriteLine(item.Text);
                        }
                    
                        break;
                    case 8:
                        check = false;
                        break;
                    default: Console.WriteLine("Check your answer!!");
                        break;
                    
                }
            }



        }
        
    }
}
