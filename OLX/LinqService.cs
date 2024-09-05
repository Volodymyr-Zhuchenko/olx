using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using OLX.DB;
using System.Data.Entity;

namespace OLX
{
    public static class LinqService
    {
        public static void UserProducts(string Login)
        {
            using (var context = new Data())
            {
                var user = context.Users
                    .Include(u => u.Products)
                    .Where(u => u.Login == Login)
                    .FirstOrDefault();

                if (user != null)
                {
                    Console.WriteLine($"Товари, які продає {user.Login}:");
                    foreach (var product in user.Products)
                    {
                        Console.WriteLine($"Назва: {product.Title}, Ціна: {product.Price}, Категорія: {product.Category}");
                    }
                }
            }
        }

        public static void SearchProductsCategory(string Category)
        {
            using (var context = new Data())
            {
                var productList = context.Products
                    .Include(p => p.User)
                    .Where(p => p.Category == Category)
                    .Select(p => new
                    {
                        ProductCategory = p.Category,
                        ProductTitle = p.Title,
                        ProductPrice = p.Price,
                        UserLogin = p.User.Login

                    })
                    .ToList();

                if (productList != null)
                {
                    foreach (var item in productList)
                    {
                        Console.WriteLine($"Категорія: {item.ProductCategory} Назва: {item.ProductTitle}, Ціна: {item.ProductPrice} Користувач: {item.UserLogin}");
                    }

                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }

        }

        public static bool CheckLogin(string Login)
        {
            bool availability = false;
            using (Data data = new Data())
            {
                var user = data.Users
                    .Where(u => u.Login == Login)
                    .FirstOrDefault();

                if (user != null)
                {
                    availability = true;
                }
            }
            return availability;
        }
    }
}
