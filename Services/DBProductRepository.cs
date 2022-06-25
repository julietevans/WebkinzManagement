using WebkinzManagement.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebkinzManagement.Services
{
    public class DBProductRepository : IProductRepository
    {
        public List<Product> Products { get; set; }


        private ProductContext productContext;


        public DBProductRepository(ProductContext _productcontext)
        {
            productContext = _productcontext;
        }


        public void AddProduct(Product product)
        {
            productContext.Products.Add(product);
            //productContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON");
            productContext.SaveChanges();
            //productContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF");
        }


        public void DeleteProduct(int? id)
        {
            var pro = productContext.Products.Find(id);
            if (pro != null)
            {
                productContext.Products.Remove(pro);
                productContext.SaveChanges();
            }
        }

        public Product GetProduct(int? id)
        {
            return productContext.Products.Find(id);
        }


        public List<Product> ReadAll()
        {
            return new List<Product>(productContext.Products);
        }


        public void UpdateProduct(Product product)
        {
            var pro = productContext.Products.Find(product.Id);
            if (pro != null)
            {
                pro.Id = product.Id;
                pro.Name = product.Name;
                pro.Description = product.Description;
                pro.Price = product.Price;
                pro.ImagePlush = product.ImagePlush;
                pro.ImageAvatar = product.ImageAvatar;
            }
            productContext.SaveChanges();
        }
    }
}
