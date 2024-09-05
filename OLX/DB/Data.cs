using System;
using System.Data.Entity;
using System.Linq;


namespace OLX.DB
{
    public class Data : DbContext
    {
        
        public Data()
            : base("name=Data")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithRequired(p => p.User)
                .HasForeignKey(p => p.UserId);
        }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}