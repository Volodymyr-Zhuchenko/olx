using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLX.DB;

namespace OLX
{
    static class UserService
    {
        public static void AddProduct(string title, decimal price, string category, User user)
        {
            using (Data data = new Data())
            {
                data.Users.Attach(user);                // Вказуємо, що працюємо з наявним користувачем, а не створюємо нового
                Product product = new Product(title, price, category, user);
                data.Products.Add(product);
                data.SaveChanges();
            }
        }

        public static void AddProduct(User user)
        {
            using (Data data = new Data())
            {
                data.Users.Attach(user);                // Вказуємо, що працюємо з наявним користувачем, а не створюємо нового
                
                Console.WriteLine("Input title");
                string title = Console.ReadLine();
                
                Console.WriteLine("Input price");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Input category");
                string category = Console.ReadLine();
                
                Product product = new Product(title, price, category, user);
                data.Products.Add(product);
                data.SaveChanges();
            }
        }

        public static void AddUser(string login, string password)
        {
            using (Data data = new Data())
            {
                User user = new User(login, password);
                data.Users.Add(user);
                data.SaveChanges();
            }
        }

        public static void AddUser()
        {
            using (Data data = new Data())
            {
                string login;
                Console.WriteLine("Input login:");
                while (true)
                {                    
                    login = Console.ReadLine();
                    if (LinqService.CheckLogin(login))
                    {
                        Console.WriteLine("This login using(\nInput a different login:");
                    }
                    else{  break;  }
                }
                

                Console.WriteLine("Input password:");
                string password = Console.ReadLine();

                User user = new User(login, password);
                data.Users.Add(user);
                data.SaveChanges();
            }
        }
    }
}
