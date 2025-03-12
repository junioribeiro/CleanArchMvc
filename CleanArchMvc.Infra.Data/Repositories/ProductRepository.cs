using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            _productContext.Add(entity);
            await _productContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<Product?> GetProductCategoryAsync(int id)
        {
            return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product entity)
        {
            _productContext.Remove(entity);
            await _productContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            _productContext.Update(entity);
            await _productContext.SaveChangesAsync();
            return entity;
        }
    }
}
