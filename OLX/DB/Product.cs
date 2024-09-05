using OLX.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLX.DB
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Product(string Title, decimal Price, string Category, User User)
        {
            this.Title = Title;
            this.Price = Price;
            this.User = User;
            this.Category = Category;
         }
        public Product() { }
    }
}
