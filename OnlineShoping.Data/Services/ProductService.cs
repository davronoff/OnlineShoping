using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.DataLayer;
using OnlineShoping.Data.Models;

namespace OnlineShoping.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopDbContext _dbContext;

        public ProductService(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }       
        public Task<Product> AddProduct(Product newProduct)
        {
            _dbContext.Products.AddAsync(newProduct);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(newProduct);
        }

        public Task DeleteProduct(Guid id)
        {
            Product product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            _dbContext.Remove(product);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(0);
        }

        public Task<List<Product>> GetAll() => _dbContext.Products.ToListAsync();
        public Task<Product> GetById(Guid id) => _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        public Task<Product> UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(product);
        }
    }
}