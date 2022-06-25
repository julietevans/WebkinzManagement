using System.Collections.Generic;
using WebkinzManagement.Models;

namespace WebkinzManagement.Services
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> Products { get; set; }
        public ProductRepository()
        {
            Products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Black Bear",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "bear1.jpg",
                    ImageAvatar = "bear2.webp"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Cheeky Dog",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "cheekydog1.jpg",
                    ImageAvatar = "cheekydog2.webp"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Cow",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "cow1.jpeg",
                    ImageAvatar = "cow2.webp"
                },
                new Product()
                {
                    Id = 4,
                    Name = "Googles",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "googles1.jpg",
                    ImageAvatar = "googles2.webp"
                },
                new Product()
                {
                    Id = 5,
                    Name = "Horse",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "horse1.jpg",
                    ImageAvatar = "horse2.webp"
                },
                new Product()
                {
                    Id = 6,
                    Name = "Panda",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "panda1.jpeg",
                    ImageAvatar = "panda2.webp"
                },
                new Product()
                {
                    Id = 7,
                    Name = "Pegasus",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "pegasus1.jpeg",
                    ImageAvatar = "pegasus2.png"
                },
                new Product()
                {
                    Id = 8,
                    Name = "Pig",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "pig1.jpeg",
                    ImageAvatar = "pig2.webp"
                },
                new Product()
                {
                    Id = 9,
                    Name = "Skunk",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "skunk1.jpg",
                    ImageAvatar = "skunk2.webp"
                },
                new Product()
                {
                    Id = 10,
                    Name = "Tiger",
                    Description = "Product description goes here.",
                    Price = 14.99,
                    ImagePlush = "tiger1.jpg",
                    ImageAvatar = "tiger2.png"
                }
            };
        }
        public List<Product> ReadAll()
        {
            return Products;
        }
        public Product GetProduct(int? id)
        {
            if(id == null)
            {
                return null;
            }
            else
            {
                return Products.Find(x => x.Id == id);
            }
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            var pro = Products.Find(x => x.Id == product.Id);
            if(pro != null)
            {
                pro.Id = product.Id;
                pro.Name = product.Name;
                pro.Description = product.Description;
                pro.Price = product.Price;
                pro.ImagePlush = product.ImagePlush;
                pro.ImageAvatar = product.ImageAvatar;
            }
        }
        public void DeleteProduct(int? id)
        {
            var pro = Products.Find(x => x.Id == id);
            if(pro != null)
            {
                Products.Remove(pro);
            }
        }
    }
}
