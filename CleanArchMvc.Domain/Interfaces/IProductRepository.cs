using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductCategoryAsync(int? id);
        Task<Product> GetByIdAsync(int? id);
        Task<Product> CreateAsync();
        Task<Product> UpdateAsync();
        Task<Product> RemoveAsync();
    }
}
