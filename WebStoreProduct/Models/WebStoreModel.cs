using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebStoreProduct.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //I am almost positive this does not belong, I believe
        //This is creating a one to one relationship,
        //Really you just need your Category Model to be a Foreign Key or Constraint of the Product Model
        public virtual List<Product> Product { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public virtual Category Category { get; set; }
    }

    public class CategoriesContext : DbContext
    {
        public DbSet<Category> Categories { get;}
        public DbSet<Product> Products { get; set; }
    }

    public class CategoryDBInitializer : DropCreateDatabaseAlways<CategoriesContext>
    {
        protected override void Seed(CategoriesContext context)
        {
            IList<Category> defaultStandards = new List<Category>();

            defaultStandards.Add(new Category() { Id = 1, Name = "Books & Audible" });
            defaultStandards.Add(new Category() { Id = 2, Name = "Movies, Music & Games" });
            defaultStandards.Add(new Category() { Id = 3, Name = "Electronics & Computers" });
            defaultStandards.Add(new Category() { Id = 4, Name = "Home, Garden & Tools" });
            defaultStandards.Add(new Category() { Id = 5, Name = "Beauty, Health & Grocery" });
            defaultStandards.Add(new Category() { Id = 6, Name = "Toys, Kids & Baby" });
            defaultStandards.Add(new Category() { Id = 7, Name = "Clothing, Shoes & Jewelry" });
            defaultStandards.Add(new Category() { Id = 8, Name = "Sport & Outdoors" });
            defaultStandards.Add(new Category() { Id = 9, Name = "Automotive & Industrial" });
            defaultStandards.Add(new Category() { Id = 10, Name = "All Categories" });

            foreach (Category std in defaultStandards)
                context.Categories.Add(std);

            base.Seed(context);
        }
    }

}