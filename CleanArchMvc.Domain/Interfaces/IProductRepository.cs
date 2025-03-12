using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> GetProductCategoryAsync(int id);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task<Product> RemoveAsync(Product entity);
    }
}
