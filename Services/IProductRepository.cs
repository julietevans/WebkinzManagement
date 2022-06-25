using System;
using System.Collections.Generic;
using WebkinzManagement.Models;

namespace WebkinzManagement.Services
{
    public interface IProductRepository
    {
        List<Product> Products { get; set; }
        List<Product> ReadAll();
        Product GetProduct(int? id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int? id);
    }
}
