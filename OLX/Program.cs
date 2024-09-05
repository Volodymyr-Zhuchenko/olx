using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLX.DB;
using System.Data.Entity;  // Простір імен для EF6

namespace OLX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using(Data data = new Data())
            //{
            //User user = data.Users.FirstOrDefault(l => l.Login == "Vova");
            //User user = new User("Bariga666", "test");

            //Product product = new Product("Xiaomi", 12500, user);
            //data.Products.Add(product);
            //Product product1 = new Product("Realmi", 15200, user);
            //data.Products.Add(product1);
            //Product product2 = new Product("Poco F1", 8450, user);
            //data.Products.Add(product2);

            //data.SaveChanges();

            //if (LogIn.Connect())
            //{
            //    using (Data data = new Data())
            //    {
            //        User user = data.Users.FirstOrDefault(l => l.Login == "Vova");
            //        Product product = new Product("Xiaomi", 12500, "Phone", user);
            //        data.Products.Add(product);
            //        data.SaveChanges();
            //    }
            //}


            //User user = LogIn.Connect();
            //UserService.AddProduct("Xiaomi", 12500, "Phone", user);

            //LinqService.SearchProductsCategory("Phone");
            //}


            Console.WriteLine("Do you have account?");
            string status = Console.ReadLine();
            bool regim = true;
            while (regim)
            {
                if (status == "y")
                {
                    User user = LogIn.Connect();
                    while (true)
                    {
                        Console.WriteLine($"{user.Login} choose operation: 1-searchByCategory, 2-addProduct 3-exit");
                        status = Console.ReadLine();
                        if (status == "1")
                        {
                            Console.WriteLine("Input category");
                            string category = Console.ReadLine();
                            LinqService.SearchProductsCategory(category);
                        }
                        else if (status == "2")
                        {
                            UserService.AddProduct(user);
                        }
                        else if (status == "3") 
                        { 
                            regim = false;
                            break;
                        }
                        else { Console.WriteLine("Input operation not corectly"); }


                    }
                }
                else if (status == "n")
                {
                    Console.WriteLine("Want you create account?");
                    status = Console.ReadLine();
                    if (status == "y")
                    {
                        UserService.AddUser();
                    }
                }

            }




            


        }
    }
}
